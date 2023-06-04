using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Service.Abstraction.Read
{
    public interface ISexReadService : IApplicationServiceBase
    {
        /// <summary>
        /// Get sex by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Sex?> GetByIdAsync(int id);
    }
}