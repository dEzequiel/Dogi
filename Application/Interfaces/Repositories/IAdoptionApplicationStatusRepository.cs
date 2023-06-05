using Domain.Entities.Adoption;

namespace Application.Interfaces.Repositories;

public interface IAdoptionApplicationStatusRepository
{
    /// <summary>
    /// Get AdoptionApplicationStatus by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionApplicationStatus> GetAsync(int id, CancellationToken ct = default);
}