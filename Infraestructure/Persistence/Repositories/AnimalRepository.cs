using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        protected readonly DbSet<Animal> _animals;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public AnimalRepository(ApplicationDbContext context)
        {
            _animals = context.Set<Animal>();
        }

        /// <inheritdoc/>
        public async Task AddAsync(Animal entity, CancellationToken ct = default)
        {
            await _animals.AddAsync(entity, ct);
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<Animal> entities, CancellationToken ct = default)
        {
            await _animals.AddRangeAsync(entities, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Animal>> FindAsync(Expression<Func<Animal, bool>> predicate, CancellationToken ct = default)
        {
            return await _animals.AsNoTracking().Where(predicate).ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Animal>> GetAllAsync(CancellationToken ct = default)
        {
            return await _animals.AsNoTracking().ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<Animal?> GetAsync(Guid id, CancellationToken ct = default)
        {
            return await _animals.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
