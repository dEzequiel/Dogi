using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Support;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class AnimalZoneRepository : IAnimalZoneRepository
    {
        protected DbSet<AnimalZone> AnimalZones;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public AnimalZoneRepository(ApplicationDbContext context)
        {
            AnimalZones = context.Set<AnimalZone>();
        }

        /// <inheritdoc />
        public async Task<AnimalZone> GetAsync(int id, CancellationToken ct = default)
        {
            var entity = await AnimalZones.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new DogiException($"AnimalZone with id ({id}) not found.");
            }

            return entity;
        }

        /// <inheritdoc />
        public IQueryable<AnimalZone> GetQueryableAsync(CancellationToken ct = default)
        {
            return AnimalZones.AsQueryable();
        }
    }
}