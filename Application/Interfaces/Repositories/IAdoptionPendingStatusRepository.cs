using Domain.Entities.Adoption;

namespace Application.Interfaces.Repositories;

public interface IAdoptionPendingStatusRepository
{
    /// <summary>
    /// Get adoption pending status by identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionPendingStatus> GetAsync(int id, CancellationToken ct = default);
}