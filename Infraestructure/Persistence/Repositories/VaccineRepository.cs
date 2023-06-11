using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        protected DbSet<Vaccine> Vaccines;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public VaccineRepository(ApplicationDbContext context)
        {
            Vaccines = context.Set<Vaccine>();
        }

        ///<inheritdoc />
        public async Task AddAsync(Vaccine entity, CancellationToken ct = default)
        {
            await Vaccines.AddAsync(entity, ct);
        }

        ///<inheritdoc />
        public async Task AddAsync(Vaccine entity)
        {
            await Vaccines.AddAsync(entity);
        }

        ///<inheritdoc />
        public async Task AddRangeAsync(IEnumerable<Vaccine> entities)
        {
            await Vaccines.AddRangeAsync(entities);
        }

        ///<inheritdoc />
        public async Task AddRangeAsync(IEnumerable<Vaccine> entities, CancellationToken ct = default)
        {
            await Vaccines.AddRangeAsync(entities, ct);
        }

        ///<inheritdoc />
        public async Task<IEnumerable<Vaccine>> GetAllByAnimalCategoryAsync(int category,
            CancellationToken ct = default)
        {
            return await Vaccines.Where(x => x.AnimalCategoryId == category).ToListAsync(ct);
        }

        public Task<IEnumerable<Vaccine>> FindAsync(Expression<Func<Vaccine, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<IEnumerable<Vaccine>> GetAllAsync()
        {
            return await Vaccines.ToListAsync();
        }

        public Task<Vaccine?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}