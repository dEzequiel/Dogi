using Application.Interfaces.Repositories;
using Domain.Entities.Authorization;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class RolePermissionRepository : IRolePermissionRepository
{
    protected DbSet<RolePermission> RolePermissions;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="context"></param>
    public RolePermissionRepository(ApplicationDbContext context)
    {
        RolePermissions = context.Set<RolePermission>();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<RolePermission>?> GetAsync(int roleId)
    {
        var entities = await RolePermissions.Where(x => x.RoleId == roleId).ToListAsync();

        return entities;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<RolePermission>?> GetAsync(IEnumerable<int> rolesIds)
    {
        var entities = await RolePermissions.Where(x => rolesIds.Contains(x.RoleId)).ToListAsync();

        return entities;
    }
}