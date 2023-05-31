using Domain.Support;

namespace Application.Interfaces.Repositories
{
    public interface IAnimalZoneRepository
    {
        /// <summary>
        /// Get AnimalZone by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<AnimalZone> GetAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Get AnimalZone queryable.
        /// </summary>
        /// <param name="ct"></param>
        IQueryable<AnimalZone> GetQueryableAsync(CancellationToken ct = default);
    }
}