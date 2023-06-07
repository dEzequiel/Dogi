using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Service.Abstraction.Read
{
    public interface IIndividualProceedingReadService : IApplicationServiceBase
    {
        /// <summary>
        /// Obtain IndividualProceeding by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IndividualProceeding?> GetByIdAsync(Guid id, CancellationToken ct = default);

        /// <summary>
        /// Get individual proceeding filter by status.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<IndividualProceeding>> GetAllByStatusAsync(int status, CancellationToken ct = default);
    }
}