using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Service.Abstraction.Write
{
    public interface ICageWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Update the occupied status of the cage.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateOccupiedStatusAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Move cage animal zone.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animalZoneId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Cage> MoveCageAnimalZoneAsync(Guid id, int animalZoneId, AdminData admin,
            CancellationToken cancellationToken);
    }
}