using Domain.Entities.Shelter;

namespace Application.Interfaces.Repositories
{
    public interface IIndividualProceedingStatusRepository
    {
        /// <summary>
        /// Get individual proceeding status by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IndividualProceedingStatus?> GetAsync(int id);

        /// <summary>
        /// Get all individual proceeding possible status.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IndividualProceedingStatus>> GetAllAsync();
    }
}