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

            var document = _mapper.Map<ReceptionDocument>(entity);

            var validDocument = _receptionDocument.Verify(document);

            if (validDocument.IsFailure)
            {
                _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> Error");

                throw new InvalidDataException(validDocument.Error.Message);
            }

            await repository.AddAsync(validDocument.Value);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ReceptionDocumentForGet>(validDocument.Value);

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
