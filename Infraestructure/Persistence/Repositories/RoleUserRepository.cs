using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Application.Service.Interfaces;
using Domain.Entities.Authorization;
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

    /// <inheritdoc />
    public Task<IEnumerable<RoleUser>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<IEnumerable<RoleUser>> FindAsync(Expression<Func<RoleUser, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task AddAsync(RoleUser entity)
    {
        await RoleUser.AddAsync(entity);
    }

    /// <inheritdoc />
    Task<RoleUser?> IRepository<RoleUser>.GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<RoleUser>> AddAsync(Guid userId, IEnumerable<int> rolesIds,
        CancellationToken ct = default)
    {
        var entities = new List<RoleUser>();

        foreach (var role in rolesIds)
        {
            entities.Add(new RoleUser()
            {
                RoleId = role,
                UserId = userId
            });
        }

        await AddRangeAsync(entities);

        return entities;
    }

    /// <inheritdoc />
    public async Task AddRangeAsync(IEnumerable<RoleUser> entities)
    {
        await RoleUser.AddRangeAsync(entities);
    }
}