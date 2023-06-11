using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Service.Abstraction.Read;

public interface IHousingTypeReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get HousingType by identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<HousingType> GetByIdAsync(int id, CancellationToken ct = default);
}