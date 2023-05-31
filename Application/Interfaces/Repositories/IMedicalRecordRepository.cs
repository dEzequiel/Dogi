using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord>
    {
        /// <summary>
        /// Get all MedicalRecords filter by status.
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<MedicalRecord>> GetAllByStatusAsync(int statusId, CancellationToken ct = default);

        /// <summary>
        /// Add new MedicalRecord.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(MedicalRecord entity, AdminData admin, CancellationToken ct = default);


        /// <summary>
        /// Mark MedicalRecord for revision..
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> SendRevisionAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Mark as checked existing MedicalRecord.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> CompleteRevisionAsync(Guid id, string? observations, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Mark as close existing MedicalRecord.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> CloseRevisionAsync(Guid id, string conclusions, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing MedicalRecord.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> UpdateAsync(Guid id, MedicalRecord newEntity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Queryable.
        /// </summary>
        /// <returns></returns>
        IQueryable<MedicalRecord> GetQueryable();
    }
}
