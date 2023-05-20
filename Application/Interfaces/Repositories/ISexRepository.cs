using Domain.Support;

namespace Application.Interfaces.Repositories
{
    public interface ISexRepository
    {
        /// <summary>
        /// Get Sex by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Sex?> GetAsync(int id);
    }
}
