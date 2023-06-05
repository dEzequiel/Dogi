using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Domain.Enums.Adoption;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class AdoptionApplicationRepository : IAdoptionApplicationRepository
{
    private const string ADOPTION_APPLICATION_NOT_FOUND = "ADOPTION APPLICATION WITH ID {0} NOT FOUND";
    private const string ADOPTION_APPLICATION_IS_WAITING_FOR_REVISION = "ADOPTION APPLICATION IS WAITING FOR REVISION";

    protected DbSet<AdoptionApplication> AdoptionApplications;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="context"></param>
    public AdoptionApplicationRepository(ApplicationDbContext context)
    {
        AdoptionApplications = context.Set<AdoptionApplication>();
    }

    /// <inheritdoc/>
    public async Task<AdoptionApplication?> GetAsync(Guid id)
    {
        var entity = await AdoptionApplications.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
        {
            throw new DogiException(string.Format(ADOPTION_APPLICATION_NOT_FOUND, id));
        }

        return entity;
    }

    /// <inheritdoc/>
    public Task<IEnumerable<AdoptionApplication>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<AdoptionApplication>> FindAsync(Expression<Func<AdoptionApplication, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task AddAsync(AdoptionApplication entity)
    {
        await AdoptionApplications.AddAsync(entity);
    }

    /// <inheritdoc/>
    public Task AddRangeAsync(IEnumerable<AdoptionApplication> entities)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task AddAsync(AdoptionApplication entity, UserData userData, CancellationToken ct = default)
    {
        await CheckIfApplicationAlreadyDone(entity.AdoptionPendingId, entity.UserId);

        entity.AdoptionApplicationStatusId = (int)AdoptionApplicationStatuses.Waiting;

        entity.Created = DateTime.UtcNow;
        entity.CreatedBy = userData.Email;

        await AdoptionApplications.AddAsync(entity, ct);
    }

    /// <inheritdoc/>
    public async Task<AdoptionApplication> GetAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await AdoptionApplications.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            throw new DogiException(string.Format(ADOPTION_APPLICATION_NOT_FOUND, id));
        }

        return entity;
    }

    private async Task CheckIfApplicationAlreadyDone(Guid adoptionPendingId, Guid userId)
    {
        var entity = await AdoptionApplications.AsNoTracking().FirstOrDefaultAsync(x =>
            x.AdoptionPendingId == adoptionPendingId
            && x.UserId == userId
            && x.AdoptionApplicationStatusId ==
            (int)AdoptionApplicationStatuses.Waiting);

        if (entity is null)
        {
            return;
        }

        throw new DogiException(ADOPTION_APPLICATION_IS_WAITING_FOR_REVISION);
    }
}