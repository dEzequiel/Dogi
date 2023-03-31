
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
        protected readonly DbSet<ReceptionDocument> _receptions;

        public ReceptionDocumentRepository(ApplicationDbContext context)
        {
            _receptions = context.Set<ReceptionDocument>();
        }

        public Task AddAsync(ReceptionDocument entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<ReceptionDocument> entities, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReceptionDocument>> FindAsync(Expression<Func<ReceptionDocument, bool>> predicate, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReceptionDocument>> GetAllAsync(CancellationToken ct = default)
        {
            return await _receptions.ToListAsync();
        }

        public Task<ReceptionDocument?> GetAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
