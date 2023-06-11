using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Write
{
    public interface IVaccineWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add collection of Vaccines..
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<Vaccine>> AddAsync(IEnumerable<Vaccine> entities, CancellationToken ct = default);
    }
}
