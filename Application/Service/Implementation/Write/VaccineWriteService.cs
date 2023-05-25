using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class VaccineWriteService : IVaccineWriteService
    {
        private readonly ILogger<VaccineWriteService> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public VaccineWriteService(ILogger<VaccineWriteService> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<IEnumerable<Vaccine>> AddAsync(IEnumerable<Vaccine> entities, CancellationToken ct = default)
        {
            Logger.LogInformation("VaccineWriteService --> AddAsync --> Start");

            Guard.Against.NullOrEmpty(entities, nameof(entities));

            var repository = UnitOfWork.VaccineRepository;

            await repository.AddRangeAsync(entities, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("VaccineWriteService --> AddAsync --> End");

            return entities;

        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
