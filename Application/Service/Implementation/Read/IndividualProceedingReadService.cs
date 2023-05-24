using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities;
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
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
