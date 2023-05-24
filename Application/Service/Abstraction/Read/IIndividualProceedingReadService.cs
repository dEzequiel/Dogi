using Crosscuting.Base.Interfaces;
using Domain.Entities;

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
    }
}
