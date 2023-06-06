using Application.DTOs.WelcomeManager;
using Application.Features.AnimalCategory.Queries;
using Application.Features.AnimalChip.Commands;
using Application.Features.Cage.Commands;
using Application.Features.Cage.Queries;
using Application.Features.IndividualPro.Commands;
using Application.Features.IndividualProceedingStatus.Queries;
using Application.Features.MedicalRecord.Comamnds;
using Application.Features.MedicalRecordStatus.Queries;
using Application.Features.Person.Commands;
using Application.Features.PersonBannedInformation.Commands;
using Application.Features.ReceptionDocument.Commands;
using Application.Features.Sex.Queries;
using Application.Features.VaccinationCard.Commands;
using Application.Interfaces;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Domain.Entities.Shelter;
using Domain.Enums.Shelter;
using Domain.Enums.Veterinary;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers
{
    public class WelcomeManager : IWelcomeManager
    {
        private const string OWNER_NOT_RESPONSIBLE = "The owner is not responsible for the animal.";

        private const string CAUSE_FIRST_ENTRY =
            "The animal has just arrived at the center, a general check-up is needed.";

        private readonly ILogger<WelcomeManager> _logger;
        private readonly IMediator Mediator;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
        public WelcomeManager(IMediator mediator, IUnitOfWork unitOfWork, ILogger<WelcomeManager> logger)
        {
            Mediator = mediator;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition you take one way or the other.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="adminData"></param>
        /// <returns>An object where the information of the reception document and the information of the chip can be consulted together with that of the owner.</returns>
        public async Task<RegisterInformation> RegisterAnimal(RegisterInformation data, AdminData adminData)
        {
            if (!data.ReceptionDocument.HasChip)
            {
                return await RegisterAnimalEntryAsync(data, adminData);
            }
            else
            {
                return await RegisterAnimalChipDataOrEntryAsync(data, adminData);
            }
        }

        private async Task<RegisterInformation> RegisterAnimalEntryAsync(RegisterInformation data, AdminData adminData)
        {
            var receptionDocumentRequest =
                await Mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));

            Guard.Against.Null(receptionDocumentRequest.Data);
            data.IndividualProceeding!.ReceptionDocumentId = receptionDocumentRequest.Data.Id;

            await AssignCageToIndividualProceeding(data.IndividualProceeding);
            await RelationshipAssignments(data.IndividualProceeding);

            var individualProceedingRequest =
                await CreateIndividualProceedingWithVaccinationCardMedicalRecordAsync(data.IndividualProceeding,
                    adminData);

            return new RegisterInformation()
            {
                ReceptionDocument = receptionDocumentRequest.Data,
                IndividualProceeding = individualProceedingRequest,
                AnimalChip = null
            };
        }

        private async Task<IndividualProceeding> CreateIndividualProceedingWithVaccinationCardMedicalRecordAsync(
            IndividualProceeding proceeding, AdminData adminData)
        {
            var vaccinationCard = await CreateVaccinationCardForIndividualProceedingAsync(adminData);

            proceeding.VaccinationCardId = vaccinationCard.Id;
            var individualProceedingRequest =
                await Mediator.Send(new InsertIndividualProceedingRequest(proceeding, adminData));

            Guard.Against.Null(individualProceedingRequest.Data);
            await CreateMedicalRecordForIndividualProceedingAsync(individualProceedingRequest.Data, adminData);

            return individualProceedingRequest.Data;
        }

        private async Task<RegisterInformation> RegisterAnimalChipDataOrEntryAsync(RegisterInformation data,
            AdminData adminData)
        {
            Guard.Against.Null(data.ReceptionDocument);
            Guard.Against.Null(data.IndividualProceeding);
            Guard.Against.Null(data.AnimalChip);
            Guard.Against.Null(data.Person);

            var receptionDocumentRequest =
                await Mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));
            data.IndividualProceeding!.ReceptionDocumentId = receptionDocumentRequest.Data.Id;

            var personRequest = await Mediator.Send(new InsertPersonRequest(data.Person));

            data.AnimalChip.PersonIdentifierId = personRequest.Data.PersonIdentifier;
            data.AnimalChip.ReceptionDocumentId = receptionDocumentRequest.Data.Id;

            var animalChipEntity = await Mediator.Send(new InsertAnimalChipRequest(data.AnimalChip, adminData));

            await RelationshipAssignments(data.IndividualProceeding);

            if (!data.AnimalChip.OwnerIsResponsible.Value)
            {
                await BanPerson(data.Person, adminData);
                await AssignCageToIndividualProceeding(data.IndividualProceeding);
                var individualProceedingForEntry =
                    await CreateIndividualProceedingWithVaccinationCardMedicalRecordAsync(data.IndividualProceeding,
                        adminData);

                return new RegisterInformation()
                {
                    ReceptionDocument = receptionDocumentRequest.Data,
                    IndividualProceeding = individualProceedingForEntry,
                    AnimalChip = animalChipEntity.Data,
                    Person = personRequest.Data
                };
            }

            data.IndividualProceeding.Name = string.IsNullOrEmpty(data.AnimalChip.Name)
                ? data.IndividualProceeding.Name
                : data.AnimalChip.Name;
            await AssignCageForIndividualProceedingWithChipOwnerResponsible(data.IndividualProceeding);
            var individualProceeding =
                await Mediator.Send(new InsertIndividualProceedingRequest(data.IndividualProceeding, adminData));

            return new RegisterInformation()
            {
                ReceptionDocument = receptionDocumentRequest.Data,
                IndividualProceeding = individualProceeding.Data,
                AnimalChip = animalChipEntity.Data,
                Person = personRequest.Data
            };
        }

        private async Task BanPerson(Person person, AdminData admin)
        {
            var ban = new PersonBannedInformation(
                id: Guid.NewGuid(),
                personIdentifierId: person.PersonIdentifier,
                observations: OWNER_NOT_RESPONSIBLE);

            await Mediator.Send(new InsertPersonBannedInformationRequest(ban, admin));
            await Mediator.Send(new BanPersonRequest(person.PersonIdentifier));
        }

        private async Task AssignCageToIndividualProceeding(IndividualProceeding individualProceeding)
        {
            var cage = await Mediator.Send(new GetFreeCageByZoneRequest(((int)AnimalZones.Quarantine)));

            Guard.Against.Null(cage.Data);

            individualProceeding.CageId = cage.Data.Id;

            await Mediator.Send(new UpdateCageOccupiedStatusRequest(individualProceeding.CageId.Value));
        }

        private async Task AssignCageForIndividualProceedingWithChipOwnerResponsible(
            IndividualProceeding individualProceeding)
        {
            var cage = await Mediator.Send(new GetFreeCageByZoneRequest(((int)AnimalZones.WaitingForOwner)));

            Guard.Against.Null(cage.Data, nameof(cage.Data));

            individualProceeding.CageId = cage.Data.Id;

            await Mediator.Send(new UpdateCageOccupiedStatusRequest(individualProceeding.CageId.Value));
        }

        private async Task CreateMedicalRecordForIndividualProceedingAsync(IndividualProceeding individualProceeding,
            AdminData adminData)
        {
            // Coger edicalRecordStatusId de la tabla MedicalRecordStatus
            var medicalRecordStatus =
                await Mediator.Send(new GetMedicalRecordStatusByIdRequest((int)MedicalRecordStatuses.Waiting));
            Guard.Against.Null(medicalRecordStatus.Data);

            var medicalRecord = new MedicalRecord(id: Guid.NewGuid(),
                medicalStatusId: medicalRecordStatus.Data.Id,
                causes: CAUSE_FIRST_ENTRY,
                individualProceedingId: individualProceeding.Id,
                observations: individualProceeding.ReceptionDocument.Observations,
                conclusions: string.Empty);

            await Mediator.Send(new InsertMedicalRecordRequest(medicalRecord, adminData));
        }

        private async Task<VaccinationCard> CreateVaccinationCardForIndividualProceedingAsync(AdminData adminData)
        {
            var vaccinationCard = new VaccinationCard(id: Guid.NewGuid(),
                observations: string.Empty);

            var addedCard = await Mediator.Send(new InsertVaccinationCardRequest(vaccinationCard, adminData));

            Guard.Against.Null(addedCard.Data);
            return addedCard.Data;
        }

        private async Task AssignOpenStatusToIndividualProceeding(IndividualProceeding individualProceeding)
        {
            var openStatus =
                await Mediator.Send(
                    new GetIndividualProceedingStatusByIdRequest(((int)IndividualProceedingStatuses.Open)));

            Guard.Against.Null(openStatus.Data);

            individualProceeding.IndividualProceedingStatusId = openStatus.Data.Id;
        }

        private async Task AssignCategoryToIndividualProceeding(IndividualProceeding individualProceeding)
        {
            var category = await Mediator.Send(new GetAnimalCategoryByIdRequest(individualProceeding.CategoryId));

            Guard.Against.Null(category.Data, nameof(category.Data));

            individualProceeding.CategoryId = category.Data.Id;
        }

        private async Task AssignSexToIndividualProceeding(IndividualProceeding individualProceeding)
        {
            var sex = await Mediator.Send(new GetSexByIdRequest(individualProceeding.SexId));

            Guard.Against.Null(sex.Data, nameof(sex.Data));

            individualProceeding.SexId = sex.Data.Id;
        }

        private async Task RelationshipAssignments(IndividualProceeding individualProceeding)
        {
            await AssignOpenStatusToIndividualProceeding(individualProceeding);
            await AssignCategoryToIndividualProceeding(individualProceeding);
            await AssignSexToIndividualProceeding(individualProceeding);
        }

        ///<inheritdoc />
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}