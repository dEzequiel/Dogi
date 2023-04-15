using Application.DTOs.ReceptionDocument;
using Application.Service.Abstraction.Command;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Command
{
    public class ReceptionDocumentWrite : IReceptionDocumentWrite
    {
        private readonly ReceptionDocument _receptionDocument;
        private readonly ILogger<ReceptionDocumentWrite> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceptionDocumentWrite(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReceptionDocumentWrite> logger, ReceptionDocument receptionDocument)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _receptionDocument = receptionDocument;
        }

        public async Task<ReceptionDocumentForGet> AddAsync(ReceptionDocumentForAdd entity)
        {
            _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> Start");

            var repository = _unitOfWork.ReceptionDocumentRepository;

            var document = _receptionDocument.Create(
                entity.HasChip,
                entity.Observations,
                entity.PickupLocation,
                entity.PickupDate);

            if (document.IsFailure)
            {
                _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> Error");

                throw new InvalidDataException(document.Error);
            }

            await repository.AddAsync(document.Value!);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ReceptionDocumentForGet>(document.Value);

            _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> End");

            return result;
        }

        public Task<bool> LogicRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReceptionDocumentForGet?> UpdateAsync(ReceptionDocumentForUpdate entity)
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
