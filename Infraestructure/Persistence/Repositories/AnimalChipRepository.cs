using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Entities.Shelter;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class AnimalChipRepository : IAnimalChipRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        protected DbSet<AnimalChip> _animalChipSet;

        /// <summary>
        /// Messages.
        /// </summary>
        private const string ANIMAL_CHIP = "AnimalChip with chip number {0} not found.";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public AnimalChipRepository(ApplicationDbContext context)
        {
            _animalChipSet = context.Set<AnimalChip>();
        }

        public Task AddAsync(AnimalChip entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<AnimalChip> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalChip>> FindAsync(Expression<Func<AnimalChip, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalChip>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnimalChip?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task AddAsync(AnimalChip entity, CancellationToken ct = default)
        {
            await _animalChipSet.AddAsync(entity, ct);
        }
    }
}