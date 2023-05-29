using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repositories
{
    public class PersonBannedInformationRepository : IPersonBannedInformationRepository
    {
        protected DbSet<PersonBannedInformation> Bans { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public PersonBannedInformationRepository(ApplicationDbContext context)
        {
            Bans = context.Set<PersonBannedInformation>();
        }

        ///<inheritdoc />
        public async Task AddAsync(PersonBannedInformation entity, AdminData adminData, CancellationToken ct = default)
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = adminData.Email;

            await Bans.AddAsync(entity, ct);
        }

        ///<inheritdoc />
        public Task<PersonBannedInformation?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public Task<IEnumerable<PersonBannedInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public Task<IEnumerable<PersonBannedInformation>> FindAsync(Expression<Func<PersonBannedInformation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task AddAsync(PersonBannedInformation entity)
        {
            await Bans.AddAsync(entity);
        }

        ///<inheritdoc />
        public Task AddRangeAsync(IEnumerable<PersonBannedInformation> entities)
        {
            throw new NotImplementedException();
        }
    }
}
