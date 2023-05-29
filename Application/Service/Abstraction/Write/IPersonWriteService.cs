using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Write
{
    public interface IPersonWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add new Person.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Person> AddAsync(Person entity, CancellationToken ct = default);

        /// <summary>
        /// Update Person ban status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Person> BanAsync(string id, CancellationToken ct = default);
    }
}
