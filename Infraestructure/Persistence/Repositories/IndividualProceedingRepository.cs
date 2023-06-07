using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Shelter;
using Domain.Enums.Shelter;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class IndividualProceedingRepository : IIndividualProceedingRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        private const string INDIVIDUAL_PROCEEDING_NOT_FOUND = "INDIVIDUAL PROCEEDING WITH ID {0} NOT FOUND.";

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
        public async Task<IEnumerable<IndividualProceeding>> GetAllFilterByStatusAsync(
            int status, CancellationToken ct = default)
        {
            return await _individualProceedings
                .Where(x => x.IndividualProceedingStatusId == status)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IndividualProceeding?> GetAsync(Guid id)
        {
            var entity = await _individualProceedings.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new DogiException(string.Format(INDIVIDUAL_PROCEEDING_NOT_FOUND, id));
            }

            return entity;
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
        public async Task UpdateAsync(Guid id, IndividualProceedingStatuses status, AdminData admin,
            CancellationToken ct = default)
        {
            var individualProceeding = await _individualProceedings.FirstOrDefaultAsync(x => x.Id == id);

            if (individualProceeding is null)
                throw new DogiException(string.Format(INDIVIDUAL_PROCEEDING_NOT_FOUND, id));

            individualProceeding.LastModified = DateTime.UtcNow;
            individualProceeding.LastModifiedBy = admin.Email;

            individualProceeding.IndividualProceedingStatusId = ((int)status);
        }

        /// <inheritdoc/>
        public async Task<IndividualProceeding> AdoptAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            var entity = await GetAsync(id);

            entity.IndividualProceedingStatusId = (int)IndividualProceedingStatuses.Adopted;
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IndividualProceeding> CloseAsync(Guid id, AdminData adminData, CancellationToken ct = default)
        {
            var entity = await GetAsync(id);

            entity.IndividualProceedingStatusId = (int)IndividualProceedingStatuses.Close;
            entity.Cage = null;
            entity.CageId = null;
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = adminData.Email;

            return entity;
        }
    }
}