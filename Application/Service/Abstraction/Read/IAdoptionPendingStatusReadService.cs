using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Service.Abstraction.Read;

public interface IAdoptionPendingStatusReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get adoption pending status by identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionPendingStatus> GetByIdAsync(int id, CancellationToken ct = default);
}