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
    public class SexRead : ISexRead
    {
        private readonly ILogger<SexRead> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public SexRead(ILogger<SexRead> logger, IUnitOfWork unitOfWork)
        {
            UnitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
            Logger = Guard.Against.Null(logger, nameof(logger));
        }

        ///<inheritdoc />
        public async Task<Sex?> GetByIdAsync(int id)
        {
            Logger.LogInformation($"SexRead --> GetByIdAsync({id}) --> Start");

            Guard.Against.Null(id, nameof(id));

            var repository = UnitOfWork.SexRepository;

            var sex = await repository.GetAsync(id);

            Logger.LogInformation($"SexRead --> GetByIdAsync({id}) --> End");

            return sex;

        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
