using System.Linq.Expressions;
using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Shelter;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class ReceptionDocumentRepository : IReceptionDocumentRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        private const string RECEPTION_DOCUMENT_NOT_FOUND = "ReceptionDocument with id {0} not found.";

        protected IQueryable<ReceptionDocument> _receptions;
        protected DbSet<ReceptionDocument> _receptionsAll;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public ReceptionDocumentRepository(ApplicationDbContext context)
        {
            _receptionsAll = context.Set<ReceptionDocument>();
            _receptions = _receptionsAll!.Where(x => !x.IsDeleted);
        }

        /// <inheritdoc/>
        public async Task AddAsync(ReceptionDocument entity)
        {
            await _receptionsAll.AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task AddAsync(ReceptionDocument entity, AdminData admin, CancellationToken ct = default)
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = admin.Email;

            await _receptionsAll.AddAsync(entity, ct);
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<ReceptionDocument> entities)
        {
            await _receptionsAll.AddRangeAsync(entities);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> GetAllAsync(CancellationToken ct = default)
        {
            return await _receptions.AsNoTracking().ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> GetAllFilterByChipPossessionAsync(bool? hasChip,
            CancellationToken ct = default)
        {
            return await _receptions.Where(x => x.HasChip == hasChip).AsNoTracking().ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> FindAsync(Expression<Func<ReceptionDocument, bool>> predicate)
        {
            return await _receptions.Where(predicate).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> GetAllAsync()
        {
            return await _receptions.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<ReceptionDocument?> GetAsync(Guid id)
        {
            return await _receptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            var entity = await _receptions.SingleOrDefaultAsync(x => x.Id == id, ct);

            if (entity == null)
                throw new DogiException(string.Format(RECEPTION_DOCUMENT_NOT_FOUND, id));

            entity.IsDeleted = true;
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;
        }
    }
}