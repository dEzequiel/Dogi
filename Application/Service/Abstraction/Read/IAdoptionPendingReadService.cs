using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Service.Abstraction;

public interface IAdoptionPendingReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get adoption pending by identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionPending> GetByIdAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Get all adoption pendings filter by status.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<AdoptionPending>> GetAllByStatusIdAsync(int status, CancellationToken ct = default);
}