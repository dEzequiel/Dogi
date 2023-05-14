using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Support;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class AnimalZoneRepository : IAnimalZoneRepository
    {
        private const string ANIMAL_ZONE_NOT_FOUND = "AnimalZone with id {0} not found.";
        protected DbSet<AnimalZone> _animalZonesAll;

        public AnimalZoneRepository(ApplicationDbContext context)
        {
            _animalZonesAll = context.Set<AnimalZone>();
        }

        public Task AddAsync(AnimalZone entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<AnimalZone> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalZone>> FindAsync(Expression<Func<AnimalZone, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalZone>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnimalZone?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalZone> GetAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IQueryable<AnimalZone> GetQueryableAsync(CancellationToken ct = default)
        {
            return _animalZonesAll.AsQueryable();
        }
    }
}