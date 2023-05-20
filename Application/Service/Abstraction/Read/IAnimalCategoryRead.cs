using Crosscuting.Base.Interfaces;
using Domain.Support;

namespace Application.Service.Abstraction.Read
{
    public interface IAnimalCategoryRead : IApplicationServiceBase
    {
        /// <summary>
        /// Get animal category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AnimalCategory?> GetByIdAsync(int id);
    }
}
