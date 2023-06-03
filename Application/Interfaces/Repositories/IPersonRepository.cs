using Application.Service.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        /// <summary>
        /// Add new Person.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(Person entity, CancellationToken ct = default);

        /// <summary>
        /// Update Person ban status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Person> BanAsync(string id, CancellationToken ct = default);
    }
}