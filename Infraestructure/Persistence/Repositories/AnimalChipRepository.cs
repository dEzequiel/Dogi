using Application.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public Task<AnimalChip> AddAsync(AnimalChip entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
