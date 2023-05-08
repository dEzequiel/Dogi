using Application.Service.Abstraction.Write;
using Application.Service.Implementation.Command;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementation.Write
{
    public class IndividualProceedingWrite : IIndividualProceedingWrite
    {
        private readonly ILogger<IndividualProceedingWrite> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public IndividualProceedingWrite(ILogger<IndividualProceedingWrite> logger, IUnitOfWork unitOfWork)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
        }

        ///<inheritdoc />
        public async Task<IndividualProceeding> AddAsync(IndividualProceeding entity, AdminData admin, CancellationToken ct = default)
        {
            _logger.LogInformation("IndividualProceedingWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.NullOrEmpty(entity.AnimalId, nameof(entity.AnimalId));
            Guard.Against.NullOrEmpty(entity.ReceptionDocumentId, nameof(entity.ReceptionDocumentId));
            Guard.Against.Null(entity.StatusId, nameof(entity.StatusId));
            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = _unitOfWork.IndividualProceedingRepository;

            await repository.AddAsync(entity, admin, ct);

            await _unitOfWork.CompleteAsync(ct);

            _logger.LogInformation("IndividualProceedingWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public Task<bool> LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<IndividualProceeding> UpdateAsync(Guid id, IndividualProceedingStatus status, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
