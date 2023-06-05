using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Domain.Enums.Adoption;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class AdoptionPendingRepository : IAdoptionPendingRepository
{
    private const string ADOPTION_PENDING_NOT_FOUND = "ADOPTION PENDING WITH ID {0} NOT FOUND.";

    private const string ADOPTION_PENDING_FOR_INDIVIDUAL_PROCEEDING_OPEND =
        "ADOPTION PENDING FOR INDIVIDUAL PROCEEDING {0} IS OPEN.";

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
    public Task<AdoptionPending?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<AdoptionPending> GetAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await AdoptionPendings.FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            throw new DogiException(string.Format(ADOPTION_PENDING_NOT_FOUND, id));
        }

        return entity;
    }

    /// <inheritdoc/>
    public async Task AddAsync(AdoptionPending entity, CancellationToken ct = default)
    {
        await CheckIfPendingAlreadyOpenAsync(entity.IndividualProceedingId);
        await AdoptionPendings.AddAsync(entity, ct);
    }

    private async Task CheckIfPendingAlreadyOpenAsync(Guid individualProceedingId)
    {
        var pending = await AdoptionPendings.FirstOrDefaultAsync(x => x.IndividualProceedingId == individualProceedingId
                                                                      && x.AdoptionPendingStatusId ==
                                                                      (int)AdoptionPendingStatuses.Open);
        if (pending is null)
        {
            return;
        }

        throw new DogiException(string.Format(ADOPTION_PENDING_FOR_INDIVIDUAL_PROCEEDING_OPEND,
            individualProceedingId));
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
    public async Task AddAsync(AdoptionPending entity)
    {
        await AdoptionPendings.AddAsync(entity);
    }

    /// <inheritdoc/>
    public Task AddRangeAsync(IEnumerable<AdoptionPending> entities)
    {
        throw new NotImplementedException();
    }
}