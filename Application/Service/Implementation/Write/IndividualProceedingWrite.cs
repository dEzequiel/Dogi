using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities.Shelter;
using Domain.Enums.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class IndividualProceedingWrite : IIndividualProceedingWriteService
    {
        private readonly ILogger<IndividualProceedingWrite> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICageWriteService _cageWriteService;
        private readonly IIndividualProceedingReadService _individualProceedingReadService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="cageWriteService"></param>
        /// <param name="individualProceedingReadService"></param>
        public IndividualProceedingWrite(ILogger<IndividualProceedingWrite> logger, IUnitOfWork unitOfWork,
            ICageWriteService cageWriteService, IIndividualProceedingReadService individualProceedingReadService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _cageWriteService = cageWriteService;
            _individualProceedingReadService = individualProceedingReadService;
        }

        ///<inheritdoc />
        public async Task<IndividualProceeding> AddAsync(IndividualProceeding entity, AdminData admin,
            CancellationToken ct = default)
        {
            _logger.LogInformation("IndividualProceedingWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.NullOrEmpty(entity.ReceptionDocumentId, nameof(entity.ReceptionDocumentId));
            Guard.Against.Null(entity.IndividualProceedingStatusId, nameof(entity.IndividualProceedingStatusId));
            Guard.Against.Null(entity.SexId, nameof(entity.SexId));
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
        public async Task<IndividualProceeding> UpdateAsync(Guid id, IndividualProceedingStatuses status,
            AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<IndividualProceeding> AdoptAsync(Guid id, AdminData adminData, CancellationToken ct = default)
        {
            _logger.LogInformation($"IndividualProceedingWrite --> AdoptAsync({id}) --> Start");

            var repository = _unitOfWork.IndividualProceedingRepository;

            var entity = await repository.AdoptAsync(id, adminData, ct);

            await _unitOfWork.CompleteAsync(ct);

            _logger.LogInformation("IndividualProceedingWrite --> AdoptAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<IndividualProceeding> CloseAsync(Guid id, AdminData adminData, CancellationToken ct = default)
        {
            _logger.LogInformation($"IndividualProceedingWrite --> CloseAsync({id}) --> Start");

            var repository = _unitOfWork.IndividualProceedingRepository;

            var entity = await _individualProceedingReadService.GetByIdAsync(id, ct);

            await _cageWriteService.FreeCageAsync(entity.CageId.Value, ct);

            await repository.CloseAsync(entity.Id, adminData, ct);

            await _unitOfWork.CompleteAsync(ct);

            _logger.LogInformation("IndividualProceedingWrite --> CloseAsync --> End");

            return entity;
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}