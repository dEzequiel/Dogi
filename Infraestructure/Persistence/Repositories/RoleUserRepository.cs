using Application.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class RoleUserRepository : IRoleUserRepository
{
    protected DbSet<RoleUser> RoleUser;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="context"></param>
    public RoleUserRepository(ApplicationDbContext context)
    {
        RoleUser = context.Set<RoleUser>();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<RoleUser>?> GetAsync(Guid userId)
    {
        var entities = await RoleUser.Where(x => x.UserId == userId).ToListAsync();

        return entities;
    }
}