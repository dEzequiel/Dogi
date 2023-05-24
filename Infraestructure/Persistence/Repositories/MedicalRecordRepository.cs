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
        public async Task<MedicalRecord> CloseRevisionAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            var entity = await GetAsync(id);

            if (entity is null)
            {
                throw new DogiException($"MedicalRecord with id {id} not found");
            }

            if (entity.IndividualProceeding is null)
            {
                throw new ArgumentNullException("The medical record does not correspond to any individual proceeding.");
            }

            if (entity.IndividualProceeding.Cage!.AnimalZone.Id != ((int)AnimalZone.Cure))
            {
                throw new ArgumentNullException("The cage is not in the medical cure area.");
            }

            entity.IndividualProceeding.Cage.AnimalZoneId = entity.IndividualProceeding.AnimalCategory.Id;
            entity.MedicalStatusId = ((int)MedicalRecordStatus.Close);

            return entity;
        }

        /// <inheritdoc/>
        public async Task<MedicalRecord> CompleteRevisionAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            var entity = await MedicalRecords.Include(i => i.IndividualProceeding)
                .ThenInclude(th => th.Cage)
                .FirstOrDefaultAsync(x => x.Id == id);


            entity.IndividualProceeding.Cage.AnimalZoneId = ((int)AnimalZone.Cure);
            entity.MedicalStatusId = ((int)MedicalRecordStatus.Checked);
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;

            return entity;
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
        public async Task<MedicalRecord?> GetAsync(Guid id)
        {
            var entity = await MedicalRecords.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new DogiException($"MedicalRecord with id {id} not found");
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<MedicalRecord> SendRevisionAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            var entity = await GetAsync(id);

            if (entity is null)
            {
                throw new DogiException($"MedicalRecord with id {id} not found");
            }


            entity.MedicalStatusId = ((int)MedicalRecordStatus.Waiting);
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;

            return entity;
        }

        /// <inheritdoc/>
        public async Task<MedicalRecord> UpdateAsync(Guid id, MedicalRecord newEntity, AdminData admin, CancellationToken ct = default)
        {
            var entity = await GetAsync(id);

            if (entity is null)
            {
                throw new DogiException($"MedicalRecord with id {id} not found");
            }

            entity.Observations = newEntity.Observations;
            entity.Conclusions = newEntity.Conclusions;
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;

            return entity;
        }

        /// <inheritdoc/>
        public IQueryable<MedicalRecord> GetQueryable()
        {
            return MedicalRecords
                .AsQueryable()
                .AsNoTracking();
        }
    }
}
