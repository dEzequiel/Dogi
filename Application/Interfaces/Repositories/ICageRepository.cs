using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities.Shelter;

namespace Application.Interfaces.Repositories
{
    public interface ICageRepository : IRepository<Cage>
    {
        /// <summary>
        /// Update the occupied status of the cage.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateOccupiedStatusAsync(Guid id, CancellationToken ct = default);


        /// <summary>
        /// Get free cage by zone.
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Cage?> GetFreeCageByZoneAsync(int zoneId, CancellationToken ct = default);

        /// <summary>
        /// Update cage.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cage"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Cage> UpdateAnimalZoneAsync(Guid id, int animalZoneId, AdminData admin, CancellationToken ct = default);
    }
}