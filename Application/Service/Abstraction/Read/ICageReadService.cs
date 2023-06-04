using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Service.Abstraction.Read
{
    public interface ICageReadService : IApplicationServiceBase
    {
        /// <summary>
        /// Obtain free random cage by zone.
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Cage> GetFreeCageByZone(int zoneId, CancellationToken ct = default);
    }
}