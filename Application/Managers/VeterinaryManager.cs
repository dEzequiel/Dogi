using Application.DTOs.VeterinaryManager;
using Application.Features.IndividualPro.Queries;
using Application.Features.MedicalRecord.Commands;
using Application.Managers.Abstraction;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers
{
    public class VeterinaryManager : IVeterinaryManager
    {
        private readonly ILogger<VeterinaryManager> Logger;
        private readonly IMediator Mediator;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        /// <param name="unitOfWork"></param>
        public VeterinaryManager(ILogger<VeterinaryManager> logger, IMediator mediator, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            Mediator = mediator;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public Task SetForMedicalRevision(IndividualProceeding individualProceeding)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<InvidiualProceedingWithMedicalRecord> CheckMedicalRecord(Guid individualProceedingId,
            Guid medicalRecordId,
            AdminData adminData,
            CancellationToken ct = default)
        {
            var individualProceeding = await Mediator.Send(new GetIndividualProceedingByIdRequest(individualProceedingId), ct);

            Guard.Against.Null(individualProceeding.Data);
            var currentMedicalRecord = individualProceeding.Data.MedicalRecords.FirstOrDefault(x => x.Id == medicalRecordId);

            Guard.Against.Null(currentMedicalRecord);
            var checkedMedicalRecord = await Mediator.Send(new CheckMedicalRecordRequest(currentMedicalRecord, adminData), ct);

            Guard.Against.Null(checkedMedicalRecord.Data);

            return new InvidiualProceedingWithMedicalRecord()
            {
                IndividualProceeding = individualProceeding.Data,
                MedicalRecord = checkedMedicalRecord.Data
            };
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
