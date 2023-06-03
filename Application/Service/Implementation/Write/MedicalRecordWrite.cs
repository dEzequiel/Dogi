using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class MedicalRecordWrite : IMedicalRecordWriteService
    {
        private readonly ILogger<MedicalRecordWrite> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public MedicalRecordWrite(ILogger<MedicalRecordWrite> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<MedicalRecord> AddAsync(MedicalRecord entity, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("MedicalRecordWrite --> AddAsync --> Start");

            Guard.Against.Null(entity);
            Guard.Against.NullOrEmpty(entity.IndividualProceedingId);
            Guard.Against.Null(entity.MedicalStatusId);
            Guard.Against.NullOrEmpty(admin.Id);
            Guard.Against.NullOrEmpty(admin.Email);

            var repository = UnitOfWork.MedicalRecordRepository;

            await repository.AddAsync(entity, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("MedicalRecordWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<MedicalRecord> SendRevision(Guid id, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("MedicalRecordWrite --> SendRevision --> Start");

            Guard.Against.NullOrEmpty(id);
            Guard.Against.NullOrEmpty(admin.Id);
            Guard.Against.NullOrEmpty(admin.Email);

            var repository = UnitOfWork.MedicalRecordRepository;

            var entity = await repository.SendRevisionAsync(id, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("MedicalRecordWrite --> SendRevision --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<MedicalRecord> CheckAsync(Guid id, string? observations, AdminData admin,
            CancellationToken ct = default)
        {
            Logger.LogInformation("MedicalRecordWrite --> CheckAsync --> Start");

            Guard.Against.NullOrEmpty(id);
            Guard.Against.NullOrEmpty(admin.Id);
            Guard.Against.NullOrEmpty(admin.Email);

            var repository = UnitOfWork.MedicalRecordRepository;

            var entity = await repository.CompleteRevisionAsync(id, observations, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("MedicalRecordWrite --> CheckAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<MedicalRecord> CloseAsync(Guid id, string conclusions, AdminData admin,
            CancellationToken ct = default)
        {
            Logger.LogInformation("MedicalRecordWrite --> CloseAsync --> Start");

            Guard.Against.NullOrEmpty(id);
            Guard.Against.NullOrEmpty(admin.Id);
            Guard.Against.NullOrEmpty(admin.Email);

            var repository = UnitOfWork.MedicalRecordRepository;

            var entity = await repository.CloseRevisionAsync(id, conclusions, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("MedicalRecordWrite --> CloseAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<MedicalRecord> UpdateAsync(Guid id, MedicalRecord newEntity, AdminData admin,
            CancellationToken ct = default)
        {
            Logger.LogInformation("MedicalRecordWrite --> CloseAsync --> Start");

            Guard.Against.NullOrEmpty(id);
            Guard.Against.NullOrEmpty(admin.Id);
            Guard.Against.NullOrEmpty(admin.Email);

            var repository = UnitOfWork.MedicalRecordRepository;

            var entity = await repository.UpdateAsync(id, newEntity, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("MedicalRecordWrite --> CloseAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        public Task<MedicalRecord> RevisionAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}