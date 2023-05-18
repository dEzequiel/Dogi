using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Domain.Enums;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repositories
{
    public class IndividualProceedingRepository : IIndividualProceedingRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        private const string INDIVIDUAL_PROCEEDING_NOT_FOUND = "IndividualProceeding with id {0} not found.";
        protected IQueryable<IndividualProceeding> _individualProceedings;
        protected DbSet<IndividualProceeding> _individualProceedingsAll;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public IndividualProceedingRepository(ApplicationDbContext context)
        {
            _individualProceedingsAll = context.Set<IndividualProceeding>();
            _individualProceedings = _individualProceedingsAll!.Where(x => !x.IsDeleted);
        }

        /// <inheritdoc/>
        public async Task AddAsync(IndividualProceeding entity, AdminData admin, CancellationToken ct = default)
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = admin.Email;
            entity.IsDeleted = false;
            entity.StatusId = 2;

            await _individualProceedingsAll.AddAsync(entity, ct);
        }

        /// <inheritdoc/>
        public async Task AddAsync(IndividualProceeding entity)
        {
            await _individualProceedingsAll.AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<IndividualProceeding> entities)
        {
            await _individualProceedingsAll.AddRangeAsync(entities);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<IndividualProceeding>> FindAsync(Expression<Func<IndividualProceeding, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IndividualProceeding>> GetAllAsync(CancellationToken ct = default)
        {
            return await _individualProceedings.AsNoTracking().ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IndividualProceeding>> GetAllAsync()
        {
            return await _individualProceedings.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IndividualProceeding>> GetAllFilterByStatusAsync(IndividualProceedingStatus status, CancellationToken ct = default)
        {
            return await _individualProceedings.AsNoTracking()
                                               .Where(x => x.StatusId == ((int)status))
                                               .ToListAsync();

        }

        /// <inheritdoc/>
        public async Task<IndividualProceeding?> GetAsync(Guid id)
        {
            return await _individualProceedings.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            var entity = await _individualProceedings.SingleOrDefaultAsync(x => x.Id == id, ct);

            if (entity == null)
                throw new DogiException(string.Format(INDIVIDUAL_PROCEEDING_NOT_FOUND, id));

            entity.IsDeleted = true;
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Guid id, IndividualProceedingStatus status, AdminData admin, CancellationToken ct = default)
        {
            var individualProceeding = await _individualProceedings.FirstOrDefaultAsync(x => x.Id == id);

            if (individualProceeding is null)
                throw new DogiException(string.Format(INDIVIDUAL_PROCEEDING_NOT_FOUND, id));

            individualProceeding.LastModified = DateTime.UtcNow;
            individualProceeding.LastModifiedBy = admin.Email;

            individualProceeding.StatusId = ((int)status);
        }
    }
}
