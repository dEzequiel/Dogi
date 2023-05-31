using Domain.Support;

namespace Application.Interfaces.Repositories
{
    public interface IVaccineStatusRepository
    {
        /// <summary>
        /// Get VaccineStatus by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VaccineStatus> GetAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Get VaccineStatus queryable.
        /// </summary>
        /// <param name="ct"></param>
        IQueryable<VaccineStatus> GetQueryableAsync(CancellationToken ct = default);
    }
}
