using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Service.Abstraction.Read;

public interface IAdoptionApplicationStatusReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get AdoptionApplicationStatus by identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionApplicationStatus> GetByIdAsync(int id, CancellationToken ct = default);
}