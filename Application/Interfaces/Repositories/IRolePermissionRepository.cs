using Domain.Entities.Authorization;

namespace Application.Interfaces.Repositories;

public interface IRolePermissionRepository
{
    /// <summary>
    /// Get roles permissions by role id.
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<IEnumerable<RolePermission>?> GetAsync(int roleId);

    /// <summary>
    /// Get roles permissions by collections of roles ids.
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<IEnumerable<RolePermission>?> GetAsync(IEnumerable<int> rolesIds);
}