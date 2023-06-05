using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class AdoptionPendingRepository : IAdoptionPendingRepository
{
    private const string ADOPTION_PENDING_NOT_FOUND = "ADOPTION PENDING WITH ID {0} NOT FOUND.";

    protected DbSet<AdoptionPending> AdoptionPendings;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="context"></param>
    public AdoptionPendingRepository(ApplicationDbContext context)
    {
        AdoptionPendings = context.Set<AdoptionPending>();
    }

    /// <inheritdoc/>
    public async Task<AdoptionPending?> GetAsync(Guid id)
    {
        var entity = await AdoptionPendings.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
        {
            throw new DogiException(string.Format(ADOPTION_PENDING_NOT_FOUND, id));
        }

        return entity;
    }

    /// <inheritdoc/>
    public Task<IEnumerable<AdoptionPending>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<AdoptionPending>> FindAsync(Expression<Func<AdoptionPending, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task AddAsync(AdoptionPending entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task AddRangeAsync(IEnumerable<AdoptionPending> entities)
    {
        throw new NotImplementedException();
    }
}