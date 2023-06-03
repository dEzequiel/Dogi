using Application.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    protected DbSet<Role> Roles;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="context"></param>
    public RoleRepository(ApplicationDbContext context)
    {
        Roles = context.Set<Role>();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Role>> GetAsync(IEnumerable<int> rolesIds)
    {
        var entities = await Roles.Where(x => rolesIds.Contains(x.Id)).ToListAsync();

        return entities;
    }
}