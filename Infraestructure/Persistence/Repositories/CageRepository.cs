using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repositories
{
    public class CageRepository : ICageRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        private const string CAGE_NOT_FOUND = "Cage with id {0} not found.";
        protected DbSet<Cage> _cageAll;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public CageRepository(ApplicationDbContext context)
        {
            _cageAll = context.Set<Cage>();
        }

        /// <inheritdoc/>
        public Task AddAsync(Cage entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task AddRangeAsync(IEnumerable<Cage> entities)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Cage>> FindAsync(Expression<Func<Cage, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Cage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Cage?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task UpdateOccupiedStatusAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _cageAll.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new DogiException(string.Format(CAGE_NOT_FOUND, id));
            }
            entity.IsOccupied = !entity.IsOccupied;
        }
    }
}
