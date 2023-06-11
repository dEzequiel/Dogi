using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Support;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class VaccineStatusRepository : IVaccineStatusRepository
    {
        protected DbSet<VaccineStatus> VaccineStatuses;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public VaccineStatusRepository(ApplicationDbContext context)
        {
            VaccineStatuses = context.Set<VaccineStatus>();
        }

        /// <inheritdoc />
        public async Task<VaccineStatus> GetAsync(int id, CancellationToken ct = default)
        {
            var entity = await VaccineStatuses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new DogiException($"VaccineStatus with id ({id}) not found.");
            }

            return entity;
        }

        /// <inheritdoc />
        public IQueryable<VaccineStatus> GetQueryableAsync(CancellationToken ct = default)
        {
            return VaccineStatuses.AsQueryable();
        }
    }
}
