using Application.Service.Interfaces;
using Domain.Entities;

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
    }
}
