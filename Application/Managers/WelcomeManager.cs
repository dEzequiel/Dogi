using Application.DTOs.WelcomeManager;
using Application.Features.Cage.Commands;
using Application.Features.Cage.Queries;
using Application.Features.IndividualPro.Commands;
using Application.Features.InsertAnimalChipRequest.Commands;
using Application.Features.ReceptionDocument.Commands;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers
{
    public class WelcomeManager : IWelcomeManager
    {
        private readonly ILogger<WelcomeManager> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
        public WelcomeManager(IMediator mediator, IUnitOfWork unitOfWork, ILogger<WelcomeManager> logger)
        {
            _mediator = mediator;
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
                return await AddReceptionDocumentWithIndividualProceedingAsync(data, adminData);
            }
            else
            {
                return await AddReceptionDocumentWithAnimalChipOwnerInformation(data, adminData);
            }
        }

        private async Task<RegisterInformation> AddReceptionDocumentWithIndividualProceedingAsync(RegisterInformation data, AdminData adminData)
        {
            var receptionDocumentRequest = await _mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));


            Guard.Against.Null(receptionDocumentRequest.Data);
            data.IndividualProceeding!.ReceptionDocumentId = receptionDocumentRequest.Data.Id;

            await AssignCageToIndividualProceeding(data.IndividualProceeding);

            var individualProceeding = await _mediator.Send(new InsertIndividualProceedingRequest(data.IndividualProceeding, adminData));
            Guard.Against.Null(individualProceeding.Data);

            return new RegisterInformation()
            {
                ReceptionDocument = receptionDocumentRequest.Data,
                IndividualProceeding = individualProceeding.Data,
                AnimalChip = null
            };
        }

        private async Task<RegisterInformation?> AddReceptionDocumentWithAnimalChipOwnerInformation(RegisterInformation data, AdminData adminData)
        {
            if (data.AnimalChip!.OwnerIsResponsible!.Value)
            {
                try
                {
                    var receptionDocumentRequest = await _mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));
                    Guard.Against.Null(receptionDocumentRequest.Data);
                    data.IndividualProceeding!.ReceptionDocumentId = receptionDocumentRequest.Data.Id;

                    var individualProceeding = await _mediator.Send(new InsertIndividualProceedingRequest(data.IndividualProceeding, adminData));
                    Guard.Against.Null(individualProceeding.Data);
                    await AssignCageForIndividualProceedingWithChipOwnerResponsible(individualProceeding.Data);

                    var animalChipEntity = await _mediator.Send(new InsertAnimalChipRequest(data.AnimalChip!, adminData));

                    return new RegisterInformation()
                    {
                        ReceptionDocument = receptionDocumentRequest.Data,
                        IndividualProceeding = individualProceeding.Data,
                        AnimalChip = animalChipEntity.Data
                    };

                }
                catch (Exception ex)
                {
                    _logger.LogInformation("WelcomeManager --> AddReceptionDocumentWithAnimalChipOwnerInformation --> Catch Exception");
                    throw new DogiException("Something went wrong when registering new information");
                }
            }
            else
            {
                await AddReceptionDocumentWithIndividualProceedingAsync(data, adminData);
            }

            return null;
        }


        private async Task AssignCageToIndividualProceeding(IndividualProceeding individualProceeding)
        {
            var cage = await _mediator.Send(new GetFreeCageByZoneRequest(((int)AnimalZone.Quarantine)));

            Guard.Against.Null(cage.Data);

            individualProceeding.CageId = cage.Data.Id;

            await _mediator.Send(new UpdateCageOccupiedStatusRequest(individualProceeding.CageId));
        }

        private async Task AssignCageForIndividualProceedingWithChipOwnerResponsible(IndividualProceeding individualProceeding)
        {
            var cage = await _mediator.Send(new GetFreeCageByZoneRequest(((int)AnimalZone.WaitingForOwner)));

            individualProceeding.CageId = cage.Data!.Id;

            await _mediator.Send(new UpdateCageOccupiedStatusRequest(individualProceeding.CageId));
        }

        ///<inheritdoc />
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
