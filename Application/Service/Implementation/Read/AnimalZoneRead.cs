using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Domain.Support;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read
{
    public class AnimalZoneRead : IAnimalZoneReadService
    {
        private readonly ILogger<AnimalZoneRead> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public AnimalZoneRead(ILogger<AnimalZoneRead> logger, IUnitOfWork unitOfWork)
        {
            UnitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
            Logger = Guard.Against.Null(logger, nameof(logger));
        }

        ///<inheritdoc />
        public async Task<AnimalZone> GetByIdAsync(int id, CancellationToken ct = default)
        {
            Logger.LogInformation($"AnimalZoneRead --> GetByIdAsync({id}) --> Start");

            Guard.Against.Null(id, nameof(id));

            var repository = UnitOfWork.AnimalZoneRepository;

            var animalZone = await repository.GetAsync(id);

            Logger.LogInformation($"AnimalZoneRead --> GetByIdAsync --> End");

            return animalZone;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
