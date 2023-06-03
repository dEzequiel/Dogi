using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class CageWrite : ICageWriteService
    {
        private readonly ILogger<CageWrite> Logger;
        private readonly IAnimalZoneReadService AnimalZoneReadService;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public CageWrite(ILogger<CageWrite> logger, IUnitOfWork unitOfWork,
            IAnimalZoneReadService animalZoneReadService)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            AnimalZoneReadService = animalZoneReadService;
        }

        ///<inheritdoc />
        public async Task<bool> UpdateOccupiedStatusAsync(Guid id, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"CageWrite --> UpdateOccupiedStatusAsync({id}) --> Start");

            Guard.Against.NullOrEmpty(id, nameof(id));

            var repository = UnitOfWork.CageRepository;

            await repository.UpdateOccupiedStatusAsync(id, cancellationToken);

            await UnitOfWork.CompleteAsync(cancellationToken);

            Logger.LogInformation($"CageWrite --> UpdateOccupiedStatusAsync({id}) --> End");

            return true;
        }

        ///<inheritdoc />
        public async Task<Cage> MoveCageAnimalZoneAsync(Guid id, int animalZoneId, AdminData admin,
            CancellationToken cancellationToken)
        {
            Logger.LogInformation($"CageWrite --> MoveCageAnimalZoneAsync({id}) --> Start");

            Guard.Against.NullOrEmpty(id, nameof(id));
            Guard.Against.Null(animalZoneId, nameof(animalZoneId));

            var animalZone = await AnimalZoneReadService.GetByIdAsync(animalZoneId);

            var repository = UnitOfWork.CageRepository;

            var cage = await repository.UpdateAnimalZoneAsync(id, animalZone.Id, admin, cancellationToken);

            await UnitOfWork.CompleteAsync();

            Logger.LogInformation("CageWrite --> MoveCageAnimalZoneAsync --> End");

            return cage;
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}