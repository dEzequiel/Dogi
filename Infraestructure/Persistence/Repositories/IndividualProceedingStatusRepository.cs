using Application.Interfaces.Repositories;
using Domain.Support;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Persistence.Repositories
{
    public class IndividualProceedingStatusRepository : IIndividualProceedingStatusRepository
    {
        private const string PROCEEDING_STATUS_NOT_FOUND = "Individual proceeding status with id {0} not found.";
        protected DbSet<IndividualProceedingStatus> IndividualProceedingStatusAll;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public IndividualProceedingStatusRepository(ApplicationDbContext context)
        {
            IndividualProceedingStatusAll = context.Set<IndividualProceedingStatus>();
        } 

        ///<inheritdoc />
        public async Task<IEnumerable<IndividualProceedingStatus>> GetAllAsync()
        {
            return await IndividualProceedingStatusAll.AsNoTracking().ToListAsync();
        }

        ///<inheritdoc />
        public async Task<IndividualProceedingStatus?> GetAsync(int id)
        {
            return await IndividualProceedingStatusAll.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
