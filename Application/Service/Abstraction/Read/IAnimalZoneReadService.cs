using Crosscuting.Base.Interfaces;
using Domain.Support;

namespace Application.Service.Abstraction.Read
{
    public interface IAnimalZoneReadService : IApplicationServiceBase
    {
        /// <summary>
        /// Get AnimalZone by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<AnimalZone> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
