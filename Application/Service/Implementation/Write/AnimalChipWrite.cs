using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementation.Write
{
    public class AnimalChipWrite : IAnimalChipWrite
    {
        private readonly ILogger<AnimalChipWrite> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AnimalChipWrite(ILogger<AnimalChipWrite> logger, IUnitOfWork unitOfWork)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
        }

        ///<inheritdoc />
        public async Task<AnimalChip> AddAsync(AnimalChip entity, AdminData admin, CancellationToken ct = default)
        {
            _logger.LogInformation("AnimalChipWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.Null(entity.ChipNumber, nameof(entity.ChipNumber));
            Guard.Against.NullOrEmpty(entity.OwnerIdentifier, nameof(entity.OwnerIdentifier));
            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));
            
            var repository = _unitOfWork.AnimalChipRepository;

            await repository.AddAsync(entity, admin, ct);

            await _unitOfWork.CompleteAsync(ct);

            _logger.LogInformation("AnimalChipWrite --> AddAsync --> End");

            return entity;
        }
    }
}
