using Crosscuting.Base.Interfaces;
using Domain.Support;

namespace Application.Service.Abstraction.Read
{
    public interface IMedicalRecordStatusReadService : IApplicationServiceBase
    {
        /// <summary>
        /// Get MedicalRecordStatus by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecordStatus> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
