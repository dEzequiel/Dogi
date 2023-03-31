
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public async Task AddAsync(ReceptionDocument entity, CancellationToken ct = default)
        {
            await _receptions.AddAsync(entity, ct);
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<ReceptionDocument> entities, CancellationToken ct = default)
        {
            await _receptions.AddRangeAsync(entities, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> FindAsync(Expression<Func<ReceptionDocument, bool>> predicate, CancellationToken ct = default)
        {
            return await _receptions.Where(predicate).ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReceptionDocument>> GetAllAsync(CancellationToken ct = default)
        {
            return await _receptions.AsNoTracking().ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<ReceptionDocument?> GetAsync(Guid id, CancellationToken ct = default)
        {
            return await _receptions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
