
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Application.Service.Interfaces;
using Crosscuting.Api.DTOs.Response;
using Azure.Core;
using Crosscuting.Base.Exceptions;
using MediatR;

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
            _receptions = _receptionsAll!.Where(x => !x.IsDeleted);
            _receptionsAll = context.Set<ReceptionDocument>();
        }

        /// <inheritdoc/>
        public async Task AddAsync(ReceptionDocument entity)
        {
            await _receptionsAll.AddAsync(entity);

        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<ReceptionDocument> entities)
        {
            await _receptionsAll.AddRangeAsync(entities);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> GetAllPaginatedAsync(PaginatedRequest paginated)
        {
            if (paginated.NumPage == default && paginated.PageSize == default)
                return await _receptions.AsNoTracking().ToListAsync();

            var skip = (paginated.NumPage - 1) * paginated.PageSize;

            return await _receptions.AsNoTracking().Skip(skip).Take(paginated.PageSize).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> GetAllPaginatedFilterByChipPossessionAsync(
            PaginatedRequest paginated, bool hasChip)
        {
            if (paginated.NumPage == default && paginated.PageSize == default)
                return await _receptions.AsNoTracking().ToListAsync();
            
            var skip = (paginated.NumPage - 1) * paginated.PageSize;

            return await _receptions.Where(x => x.HasChip == hasChip)
                                            .AsNoTracking().Skip(skip)
                                            .Take(paginated.PageSize)
                                            .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<int> GetAllCountAsync()
        {
            return await _receptions.CountAsync();
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
        public async Task LogicRemoveAsync(Guid id)
        {
            var entity = await _receptions.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new DogiException(string.Format(RECEPTION_DOCUMENT_NOT_FOUND, id));

            entity.IsDeleted = true;
        }
    }
}
