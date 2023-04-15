using Application.DTOs.ReceptionDocument;
using Application.Service.Abstraction.Command;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Service.Implementation.Command
{
    public class ReceptionDocumentWrite : IReceptionDocumentWrite
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceptionDocumentWrite(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReceptionDocumentForGet> AddAsync(ReceptionDocumentForAdd entity)
        {
            var repository = _unitOfWork.ReceptionDocumentRepository;

            var document = ReceptionDocument.Create(
                entity.HasChip, 
                entity.Observations, 
                entity.PickupLocation, 
                entity.PickupDate);

            if (!document.IsSuccess)
                throw new Exception();

            await repository.AddAsync(document.Value!);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ReceptionDocumentForGet>(document.Value);

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
