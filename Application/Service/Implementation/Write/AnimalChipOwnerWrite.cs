using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class AnimalChipOwnerWrite : IAnimalChipOwnerWrite
    {
        private readonly ILogger<AnimalChipOwnerWrite> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AnimalChipOwnerWrite(ILogger<AnimalChipOwnerWrite> logger, IUnitOfWork unitOfWork)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
        }

        ///<inheritdoc />
        public async Task<AnimalChipOwner> AddAsync(AnimalChipOwner entity, AdminData admin, CancellationToken ct = default)
        {
            _logger.LogInformation("AnimalChipOwnerWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.Null(entity.Name, nameof(entity.Name));
            Guard.Against.NullOrEmpty(entity.Lastname, nameof(entity.Lastname));
            Guard.Against.Null(entity.Address, nameof(entity.Address));
            Guard.Against.Null(entity.IsResponsible, nameof(entity.IsResponsible));
            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = _unitOfWork.AnimalChipOwnerRepository;

            await repository.AddAsync(entity, admin, ct);

            await _unitOfWork.CompleteAsync(ct);

            _logger.LogInformation("AnimalChipOwnerWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public Task<bool> DeleteAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public Task<AnimalChipOwner> UpdateAsync(Guid id, AnimalChipOwner newEntity, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
