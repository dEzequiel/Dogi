using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Domain.Support;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementation.Read
{
    /// <summary>
    /// IndividualProceedingStatus Read Service Implementation.
    /// </summary>
    public class IndividualProceedingStatusRead : IIndividualProceedingStatusRead
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
