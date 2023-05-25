using Application.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public Task AddRangeAsync(IEnumerable<Vaccine> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vaccine>> FindAsync(Expression<Func<Vaccine, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vaccine>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vaccine?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
