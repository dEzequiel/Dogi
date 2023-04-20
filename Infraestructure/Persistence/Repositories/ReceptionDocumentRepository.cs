
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Application.DTOs.ReceptionDocument;
using Application.Service.Interfaces;
using Crosscuting.Api.DTOs.Response;

namespace Infraestructure.Persistence.Repositories
{
    public class ReceptionDocumentRepository : IReceptionDocumentRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        protected readonly DbSet<ReceptionDocument> _receptions;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public ReceptionDocumentRepository(ApplicationDbContext context)
        {
            _receptions = context.Set<ReceptionDocument>();
        }

        /// <inheritdoc/>
        public async Task AddAsync(ReceptionDocument entity)
        {
            await _receptions.AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<ReceptionDocument> entities)
        {
            await _receptions.AddRangeAsync(entities);
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
    }
}
