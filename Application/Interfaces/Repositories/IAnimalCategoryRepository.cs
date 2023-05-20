using Domain.Support;

namespace Application.Interfaces.Repositories
{
    public interface IAnimalCategoryRepository
    {
        /// <summary>
        /// Get animal category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AnimalCategory?> GetAsync(int id);
    }
}
