using Crosscuting.Base.Interfaces;
using Domain.Entities.Authorization;

namespace Application.Service.Abstraction.Write;

public interface IRoleUserWriteService : IApplicationServiceBase
{
    /// <summary>
    /// Add new User to a Role.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<RoleUser>> AddAsync(Guid userId, IEnumerable<int> rolesIds, CancellationToken ct = default);
}