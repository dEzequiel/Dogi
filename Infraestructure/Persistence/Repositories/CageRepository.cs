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
        private const string CAGE_IS_OCCUPIED = "Cage with id {0} is occupied.";
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

        public async Task<Cage?> GetFreeCageByZoneAsync(int zoneId, CancellationToken ct = default)
        {
            return await _cageAll.FirstOrDefaultAsync(x => x.ZoneId == zoneId && !x.IsOccupied);
        }

        /// <inheritdoc />
        public async Task UpdateOccupiedStatusAsync(Guid id, CancellationToken ct = default)
        {
            var isOccupied = await CheckIfOccupied(id);

            if (isOccupied)
            {
                throw new DogiException(string.Format(CAGE_IS_OCCUPIED, id));
            }

            var entity = await _cageAll.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new DogiException(string.Format(CAGE_NOT_FOUND, id));
            }

            entity.IsOccupied = true;
        }

        private async Task<bool> CheckIfOccupied(Guid id)
        {
            var entity = await _cageAll.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new DogiException(string.Format(CAGE_NOT_FOUND, id));
            }

            if (entity.IsOccupied)
            {
                return true;
            }

            return false;
        }
    }
}
