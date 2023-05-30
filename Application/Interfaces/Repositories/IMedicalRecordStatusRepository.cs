using Domain.Support;

namespace Application.Interfaces.Repositories
{
    public interface IMedicalRecordStatusRepository
    {
        /// <summary>
        /// Get MedicalRecordStatus by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<MedicalRecordStatus> GetAsync(int id, CancellationToken ct = default);
    }
}
