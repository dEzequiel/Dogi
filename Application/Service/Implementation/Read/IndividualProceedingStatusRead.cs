using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read
{
    /// <summary>
    /// IndividualProceedingStatus Read Service Implementation.
    /// </summary>
    public class IndividualProceedingStatusRead : IIndividualProceedingStatusReadService
    {
        private readonly ILogger<IndividualProceedingStatusRead> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public IndividualProceedingStatusRead(ILogger<IndividualProceedingStatusRead> logger, IUnitOfWork unitOfWork)
        {
            UnitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
            Logger = Guard.Against.Null(logger, nameof(logger));
        }

        ///<inheritdoc />
        public async Task<IndividualProceedingStatus> GetByIdAsync(int id)
        {
            Logger.LogInformation($"IndividualProceedingStatusRead --> GetByIdAsync({id}) --> Start");

            Guard.Against.Null(id, nameof(id));

            var repository = UnitOfWork.IndividualProceedingStatusRepository;

            var status = await repository.GetAsync(id);

            Logger.LogInformation($"IndividualProceedingStatusRead --> GetByIdAsync({id}) --> End");

            return status;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}