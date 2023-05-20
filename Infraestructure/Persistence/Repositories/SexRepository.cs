using Application.Interfaces.Repositories;
using Domain.Support;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class SexRepository : ISexRepository
    {
        private const string SEX_NOT_FOUND = "Sex with id {0} not found.";
        protected DbSet<Sex> SexAll;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public SexRepository(ApplicationDbContext context)
        {
            SexAll = context.Set<Sex>();
        }

        ///<inheritdoc />
        public async Task<Sex?> GetAsync(int id)
        {
            return await SexAll.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
