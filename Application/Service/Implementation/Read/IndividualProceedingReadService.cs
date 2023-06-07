using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read
{
    public class IndividualProceedingReadService : IIndividualProceedingReadService
    {
        private readonly ILogger<IndividualProceedingReadService> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public IndividualProceedingReadService(ILogger<IndividualProceedingReadService> logger, IUnitOfWork unitOfWork)
        {
            Logger = Guard.Against.Null(logger);
            UnitOfWork = Guard.Against.Null(unitOfWork);
        }

        ///<inheritdoc />
        public async Task<IndividualProceeding?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            Logger.LogInformation($"IndividualProceedingReadService --> GetByIdAsync({id}) --> Start");

            Guard.Against.NullOrEmpty(id, nameof(id));

            var repository = UnitOfWork.IndividualProceedingRepository;

            var individualProceeding = await repository.GetAsync(id);

            Logger.LogInformation($"IndividualProceedingReadService --> GetByIdAsync({id}) --> End");

            return individualProceeding;
        }

        ///<inheritdoc />
        public async Task<IEnumerable<IndividualProceeding>> GetAllByStatusAsync(int status,
            CancellationToken ct = default)
        {
            Logger.LogInformation($"IndividualProceedingReadService --> GetAllByStatusAsync({status}) --> Start");

            Guard.Against.Null(status, nameof(status));

            var repository = UnitOfWork.IndividualProceedingRepository;

            var individualProceedings = await repository.GetAllFilterByStatusAsync(status);

            Logger.LogInformation($"IndividualProceedingReadService --> GetAllByStatusAsync({status}) --> End");

            return individualProceedings;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}