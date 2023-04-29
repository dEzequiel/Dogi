using Application.Service.Abstraction;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
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

        public async Task<ReceptionDocument> AddAsync(ReceptionDocument entity)
        {
            _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            //Guard.Against.Null(entity.PickupDate, nameof(entity.PickupDate));
            Guard.Against.NullOrEmpty(entity.PickupLocation, nameof(entity.PickupLocation));

            var repository = _unitOfWork.ReceptionDocumentRepository;

            await repository.AddAsync(entity);

            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> End");

            return entity;
        }

        public Task<bool> LogicRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
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
