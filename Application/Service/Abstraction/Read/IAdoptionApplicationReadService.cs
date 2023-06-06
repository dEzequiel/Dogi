using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Service.Abstraction.Read;

public interface IAdoptionApplicationReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get AdoptionApplication by identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionApplication> GetByIdAsync(Guid id, CancellationToken ct = default);
}