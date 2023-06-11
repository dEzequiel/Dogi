using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class AdoptionPendingStatusRepository : IAdoptionPendingStatusRepository
{
    private const string ADOPTION_PENDING_NOT_FOUND = "ADOPTION PENDING WITH ID {0} NOT FOUND.";
    protected DbSet<AdoptionPendingStatus> AdoptionPendingStatuses;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionPendingStatuses"></param>
    public AdoptionPendingStatusRepository(ApplicationDbContext context)
    {
        AdoptionPendingStatuses = context.Set<AdoptionPendingStatus>();
    }

    ///<inheritdoc />
    public async Task<AdoptionPendingStatus> GetAsync(int id, CancellationToken ct = default)
    {
        var entity = await AdoptionPendingStatuses.FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            throw new DogiException(String.Format(ADOPTION_PENDING_NOT_FOUND, id));
        }

        return entity;
    }
}