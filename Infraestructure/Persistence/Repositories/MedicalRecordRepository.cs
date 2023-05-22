using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        protected DbSet<MedicalRecord> MedicalRecords;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public MedicalRecordRepository(ApplicationDbContext context)
        {
            MedicalRecords = context.Set<MedicalRecord>();
        }

        /// <inheritdoc/>
        public async Task AddAsync(MedicalRecord entity, AdminData admin, CancellationToken ct = default)
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = admin.Email;

            await MedicalRecords.AddAsync(entity, ct);
        }

        /// <inheritdoc/>
        public async Task AddAsync(MedicalRecord entity)
        {
            await MedicalRecords.AddAsync(entity);
        }

        /// <inheritdoc/>
        public Task AddRangeAsync(IEnumerable<MedicalRecord> entities)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<MedicalRecord> CloseRevisionAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<MedicalRecord> CompleteRevisionAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<MedicalRecord>> FindAsync(Expression<Func<MedicalRecord, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<MedicalRecord>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<MedicalRecord?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<MedicalRecord> SendForRevisionAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<MedicalRecord> UpdateAsync(Guid id, MedicalRecord entity, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
