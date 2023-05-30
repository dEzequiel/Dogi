using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Write
{
    public interface IMedicalRecordWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add new MedicalRecord.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> AddAsync(MedicalRecord entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Mark as checked existing MedicalRecord.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> CheckAsync(Guid id, string? observations, AdminData admin, CancellationToken ct = default);


        /// <summary>
        /// Send for revision existing MedicalRecord.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> RevisionAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Mark as close existing MedicalRecord.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> CloseAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing MedicalRecord.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecord> UpdateAsync(Guid id, MedicalRecord newEntity, AdminData admin, CancellationToken ct = default);
    }
}
