﻿using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
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
            Guard.Against.Null(entity.MedicalRecordStatus);
            Guard.Against.NullOrEmpty(admin.Id);
            Guard.Against.NullOrEmpty(admin.Email);

            var repository = UnitOfWork.MedicalRecordRepository;

            await repository.AddAsync(entity, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("MedicalRecordWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public Task<MedicalRecord> MarkAsCheckedAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public Task<MedicalRecord> MarkAsCloseAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public Task<MedicalRecord> UpdateAsync(MedicalRecord entity, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
