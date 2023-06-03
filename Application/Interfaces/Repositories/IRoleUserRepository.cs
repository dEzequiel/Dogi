using Application.Service.Interfaces;
using Domain.Entities.Authorization;

namespace Application.Interfaces.Repositories;

public interface IRoleUserRepository : IRepository<RoleUser>
{
    /// <summary>
    /// Get User roles by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<IEnumerable<RoleUser>?> GetAsync(Guid userId);

    /// <summary>
    /// Add user to a role.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<IEnumerable<RoleUser>> AddAsync(Guid userId, IEnumerable<int> rolesIds, CancellationToken ct = default);
}