using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Read;

public interface IMedicalRecordReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get all medical records by status.
    /// </summary>
    /// <param name="statusId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<MedicalRecord>> GetAllByStatusAsync(int statusId, CancellationToken ct = default);

    /// <summary>
    /// Get all medical records.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<MedicalRecord>> GetAllAsync();
}