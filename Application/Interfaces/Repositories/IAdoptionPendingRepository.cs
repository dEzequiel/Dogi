using Application.Service.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Interfaces.Repositories;

public interface IAdoptionPendingRepository : IRepository<AdoptionPending>
{
    /// <summary>
    /// Get AdoptionPending by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionPending> GetAsync(Guid id, CancellationToken ct = default);
}