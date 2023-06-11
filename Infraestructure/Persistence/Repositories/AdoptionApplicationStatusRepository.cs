using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class AdoptionApplicationStatusRepository : IAdoptionApplicationStatusRepository
{
    protected DbSet<AdoptionApplicationStatus> AdoptionApplications;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AdoptionApplicationStatusRepository(ApplicationDbContext context)
    {
        AdoptionApplications = context.Set<AdoptionApplicationStatus>();
    }

    /// <inheritdoc />
    public async Task<AdoptionApplicationStatus> GetAsync(int id, CancellationToken ct = default)
    {
        var entity = await AdoptionApplications.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            throw new DogiException($"AdoptionApplication with id ({id}) not found.");
        }

        return entity;
    }
}