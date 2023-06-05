using Application.Interfaces;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class HousingTypeRepository : IHousingTypeRepository
{
    protected DbSet<HousingType> HousingTypes;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="context"></param>
    public HousingTypeRepository(ApplicationDbContext context)
    {
        HousingTypes = context.Set<HousingType>();
    }

    /// <inheritdoc />
    public async Task<HousingType> GetAsync(int id, CancellationToken ct = default)
    {
        var entity = await HousingTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        if (entity is null)
        {
            throw new DogiException($"HousingType with id ({id}) not found.");
        }

        return entity;
    }
}