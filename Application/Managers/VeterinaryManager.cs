﻿using Application.DTOs.VeterinaryManager;
using Application.Features.MedicalRecord.Commands;
using Application.Features.VaccinationCardVaccine.Commands;
using Application.Managers.Abstraction;
using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Domain.Enums;
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
        public VeterinaryManager(ILogger<VeterinaryManager> logger, IMediator mediator, IUnitOfWork unitOfWork, IVaccinationCardVaccineReadService vaccinationCardVaccineReadService)
        {
            Logger = logger;
            Mediator = mediator;
            UnitOfWork = unitOfWork;
            VaccinationCardVaccineReadService = vaccinationCardVaccineReadService;
        }

        ///<inheritdoc />
        public Task SetForMedicalRevision(IndividualProceeding individualProceeding)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<InvidiualProceedingWithMedicalRecord> CheckMedicalRecord(Guid medicalRecordId,
            AdminData adminData,
            CancellationToken ct = default)
        {
            var checkedMedicalRecord = await Mediator.Send(new CheckMedicalRecordRequest(medicalRecordId, adminData), ct);

            Guard.Against.Null(checkedMedicalRecord.Data);

            return new InvidiualProceedingWithMedicalRecord()
            {
                IndividualProceeding = checkedMedicalRecord.Data.IndividualProceeding,
                MedicalRecord = checkedMedicalRecord.Data
            };
        }

        ///<inheritdoc />
        public async Task<IndividualProceedingWithVaccinationCard> AssignPendingVaccine(Guid vaccinationCardId, Guid vaccineId, AdminData adminData, CancellationToken ct = default)
        {
            var vaccinationCardVaccine = new VaccinationCardVaccine()
            {
                VaccinationCardId = vaccinationCardId,
                VaccineId = vaccineId,
                VaccineStatusId = (int)VaccineStatus.Pending,
                VaccineStart = null,
                VaccineEnd = null,
            };

            var response = await Mediator.Send(new InsertVaccinationCardVaccineVaccineRequest(vaccinationCardVaccine, adminData), ct);

            Guard.Against.Null(response.Data);
            var currentVaccinationCardVaccine = await VaccinationCardVaccineReadService.GetByIdLoadedAsync(response.Data.Id);
            Guard.Against.Null(currentVaccinationCardVaccine);

            return new IndividualProceedingWithVaccinationCard()
            {
                IndividualProceeding = currentVaccinationCardVaccine.VaccinationCard.IndividualProceeding,
                VaccinationCard = currentVaccinationCardVaccine.VaccinationCard
            };
        }

        ///<inheritdoc />
        public async Task<VaccinationCardVaccine> Vaccine(Guid vaccinationCardId, Guid vaccineId, AdminData adminData, CancellationToken ct = default)
        {
            var response = await Mediator.Send(new VaccineExistingVaccinationCardVaccineVaccineRequest(vaccinationCardId, vaccineId, adminData), ct);

            Guard.Against.Null(response.Data);

            return response.Data;
        }


        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


    }
}
