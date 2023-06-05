using Application.DTOs.VeterinaryManager;
using Application.Features.Cage.Commands;
using Application.Features.IndividualPro.Queries;
using Application.Features.MedicalRecord.Comamnds;
using Application.Features.MedicalRecord.Commands;
using Application.Features.MedicalRecordStatus.Queries;
using Application.Features.VaccinationCardVaccine.Commands;
using Application.Interfaces;
using Application.Managers.Abstraction;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Domain.Enums.Shelter;
using Domain.Enums.Veterinary;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers
{
    public class VeterinaryManager : IVeterinaryManager
    {
        private readonly ILogger<VeterinaryManager> Logger;
        private readonly IMediator Mediator;
        private readonly IVaccinationCardVaccineReadService VaccinationCardVaccineReadService;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        /// <param name="unitOfWork"></param>
        public VeterinaryManager(ILogger<VeterinaryManager> logger, IMediator mediator, IUnitOfWork unitOfWork,
            IVaccinationCardVaccineReadService vaccinationCardVaccineReadService)
        {
            Logger = logger;
            Mediator = mediator;
            UnitOfWork = unitOfWork;
            VaccinationCardVaccineReadService = vaccinationCardVaccineReadService;
        }

        ///<inheritdoc />
        public async Task<IndividualProceedingWithMedicalRecord> CreateMedicalRecord(
            Guid individualProceedingId,
            MedicalRecord medicalRecord,
            IEnumerable<Guid>? vaccinesIds,
            AdminData adminData,
            CancellationToken ct = default)
        {
            var individualProceeding =
                await Mediator.Send(new GetIndividualProceedingByIdRequest(individualProceedingId), ct);
            Guard.Against.Null(individualProceeding.Data);

            await Mediator.Send(new MoveCageAnimalZoneRequest(individualProceeding.Data.CageId.Value,
                ((int)AnimalZones.WaitingForMedicalRevision), adminData));

            var medicalRecordStatus =
                await Mediator.Send(new GetMedicalRecordStatusByIdRequest((int)MedicalRecordStatuses.Waiting), ct);
            Guard.Against.Null(medicalRecordStatus.Data);


            medicalRecord.IndividualProceedingId = individualProceeding.Data.Id;
            medicalRecord.MedicalStatusId = medicalRecordStatus.Data.Id;

            var createdMedicalRecord =
                await Mediator.Send(new InsertMedicalRecordRequest(medicalRecord, adminData), ct);
            Guard.Against.Null(createdMedicalRecord.Data);

            if (vaccinesIds is null)
            {
                return new IndividualProceedingWithMedicalRecord()
                {
                    IndividualProceeding = individualProceeding.Data,
                    MedicalRecord = createdMedicalRecord.Data
                };
            }


            if (!individualProceeding.Data.VaccinationCardId.HasValue)
            {
                throw new DogiException(
                    $"No vaccination card found for individual proceeding with id: ({individualProceeding.Data.Id})");
            }

            await Mediator.Send(
                new InsertCollectionVaccinationCardVaccineVaccinesRequest(
                    individualProceeding.Data.VaccinationCardId.Value, vaccinesIds, adminData));


            return new IndividualProceedingWithMedicalRecord()
            {
                IndividualProceeding = createdMedicalRecord.Data.IndividualProceeding,
                MedicalRecord = createdMedicalRecord.Data
            };
        }

        ///<inheritdoc />
        public async Task<IndividualProceedingWithMedicalRecord> CheckMedicalRecord(
            Guid medicalRecordId,
            string? observations,
            AdminData adminData,
            CancellationToken ct = default)
        {
            var checkedMedicalRecord =
                await Mediator.Send(new CheckMedicalRecordRequest(medicalRecordId, observations, adminData), ct);

            Guard.Against.Null(checkedMedicalRecord.Data);

            return new IndividualProceedingWithMedicalRecord()
            {
                IndividualProceeding = checkedMedicalRecord.Data.IndividualProceeding,
                MedicalRecord = checkedMedicalRecord.Data
            };
        }

        ///<inheritdoc />
        public async Task<IndividualProceedingWithMedicalRecord> CloseMedicalRecord(
            Guid medicalRecordId,
            string conclusions,
            AdminData AdminData,
            CancellationToken ct = default)
        {
            Logger.LogInformation("VeterinaryManager --> CloseMedicalRecord --> Start");

            var closedMedicalRecord =
                await Mediator.Send(new CloseMedicalRecordRequest(medicalRecordId, conclusions, AdminData), ct);

            Guard.Against.Null(closedMedicalRecord.Data);

            Logger.LogInformation("VeterinaryManager --> CloseMedicalRecord --> End");

            return new IndividualProceedingWithMedicalRecord()
            {
                IndividualProceeding = closedMedicalRecord.Data.IndividualProceeding,
                MedicalRecord = closedMedicalRecord.Data
            };
        }

        ///<inheritdoc />
        public async Task<IndividualProceedingWithVaccinationCard> AssignPendingVaccine(Guid vaccinationCardId,
            Guid vaccineId, AdminData adminData, CancellationToken ct = default)
        {
            var vaccinationCardVaccine = new VaccinationCardVaccine()
            {
                VaccinationCardId = vaccinationCardId,
                VaccineId = vaccineId,
                VaccineStatusId = (int)VaccineStatuses.Pending,
                VaccineStart = null,
                VaccineEnd = null,
            };

            var response =
                await Mediator.Send(new InsertVaccinationCardVaccineVaccineRequest(vaccinationCardVaccine, adminData),
                    ct);

            Guard.Against.Null(response.Data);
            var currentVaccinationCardVaccine =
                await VaccinationCardVaccineReadService.GetByIdLoadedAsync(response.Data.Id);
            Guard.Against.Null(currentVaccinationCardVaccine);

            return new IndividualProceedingWithVaccinationCard()
            {
                IndividualProceeding = currentVaccinationCardVaccine.VaccinationCard.IndividualProceeding,
                VaccinationCard = currentVaccinationCardVaccine.VaccinationCard
            };
        }

        ///<inheritdoc />
        public async Task<IEnumerable<VaccinationCardVaccine>> Vaccine(Guid vaccinationCardId,
            VaccinesToComplish vaccinesIds, AdminData adminData, CancellationToken ct = default)
        {
            var response =
                await Mediator.Send(new VaccinationCardVaccineVaccineRequest(vaccinationCardId, vaccinesIds, adminData),
                    ct);

            Guard.Against.Null(response.Data);

            return response.Data;
        }


        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}