using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Domain.Enums.Shelter;
using Domain.Enums.Veterinary;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<MedicalRecord>> GetAllByStatusAsync(int statusId, CancellationToken ct = default)
        {
            return await MedicalRecords.Where(x => x.MedicalStatusId == statusId).ToListAsync(ct);
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
        public async Task<MedicalRecord> CloseRevisionAsync(Guid id, string conclusions, AdminData admin,
            CancellationToken ct = default)
        {
            var entity = await MedicalRecords.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new DogiException($"MedicalRecord with id {id} not found");
            }

            if (entity.IndividualProceeding.Cage!.AnimalZoneId != ((int)AnimalZones.Cure) &&
                entity.IndividualProceeding.Cage!.AnimalZoneId != ((int)AnimalZones.WaitingForMedicalRevision))
            {
                throw new DogiException("The cage is not in the cure area.");
            }

            entity.Conclusions = conclusions;
            entity.IndividualProceeding.Cage.AnimalZoneId = entity.IndividualProceeding.CategoryId;
            entity.MedicalStatusId = ((int)MedicalRecordStatuses.Close);

            return entity;
        }

        /// <inheritdoc/>
        public async Task<MedicalRecord> CompleteRevisionAsync(Guid id, string? observations, AdminData admin,
            CancellationToken ct = default)
        {
            var entity = await MedicalRecords.FirstOrDefaultAsync(x => x.Id == id);

            entity.Observations = entity.Observations + " " + observations;

            entity.IndividualProceeding.Cage.AnimalZoneId = ((int)AnimalZones.Cure);
            entity.MedicalStatusId = ((int)MedicalRecordStatuses.Checked);
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
        public async Task<IEnumerable<MedicalRecord>> GetAllAsync()
        {
            return await MedicalRecords.ToListAsync();
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


            entity.MedicalStatusId = ((int)MedicalRecordStatuses.Waiting);
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;

            return entity;
        }

        /// <inheritdoc/>
        public async Task<MedicalRecord> UpdateAsync(Guid id, MedicalRecord newEntity, AdminData admin,
            CancellationToken ct = default)
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