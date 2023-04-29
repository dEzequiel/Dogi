using Application.Service.Abstraction;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Command
{
    public class ReceptionDocumentWrite : IReceptionDocumentWrite
    {
        private readonly ILogger<ReceptionDocumentWrite> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceptionDocumentWrite(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReceptionDocumentWrite> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        ///<inheritdoc />
        public async Task<ReceptionDocument> AddAsync(ReceptionDocument entity, AdminData admin)
        {
            _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            //Guard.Against.Null(entity.PickupDate, nameof(entity.PickupDate));
            Guard.Against.NullOrEmpty(entity.PickupLocation, nameof(entity.PickupLocation));
            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = _unitOfWork.ReceptionDocumentRepository;

            await repository.AddAsync(entity, admin);

            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<bool> LogicRemoveAsync(Guid id, AdminData admin)
        {
            _logger.LogInformation($"ReceptionDocumentWrite --> LogicRemoveAsync({id}) --> Start");

            Guard.Against.NullOrEmpty(id, nameof(id));

            var repository = _unitOfWork.ReceptionDocumentRepository;

            await repository.LogicRemoveAsync(id, admin);

            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("ReceptionDocumentWrite --> LogicRemoveAsync --> End");

            return true;

        }

        public Task<ReceptionDocument?> UpdateAsync(ReceptionDocument entity)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
