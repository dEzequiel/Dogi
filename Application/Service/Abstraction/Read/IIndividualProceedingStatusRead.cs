using Crosscuting.Base.Interfaces;
using Domain.Support;

namespace Application.Service.Abstraction.Read
{
    /// <summary>
    /// IndividualProceedingStatus Read Service Definition.
    /// </summary>
    public interface IIndividualProceedingStatusRead : IApplicationServiceBase
    {
        /// <summary>
        /// Get individual proceeding status by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IndividualProceedingStatus> GetByIdAsync(int id);
    }
}
