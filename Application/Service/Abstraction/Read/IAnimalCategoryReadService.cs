using Crosscuting.Base.Interfaces;
using Domain.Support;

namespace Application.Service.Abstraction.Read
{
    public interface IAnimalCategoryReadService : IApplicationServiceBase
    {
        /// <summary>
        /// Get animal category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AnimalCategory?> GetByIdAsync(int id);
    }
}
