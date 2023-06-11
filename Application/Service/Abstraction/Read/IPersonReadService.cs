using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Service.Abstraction.Read;

public interface IPersonReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get Person by User identifier.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<Person> GetByUserIdAsync(Guid userId, CancellationToken ct = default);
}