using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Service.Abstraction.Read
{
    /// <summary>
    /// IndividualProceedingStatus Read Service Definition.
    /// </summary>
    public interface IIndividualProceedingStatusReadService : IApplicationServiceBase
    {
        /// <summary>
        /// Get individual proceeding status by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IndividualProceedingStatus> GetByIdAsync(int id);
    }
}