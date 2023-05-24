using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Write
{
    public interface IVaccinationCardWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add new VaccinationCard.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VaccinationCard> AddAsync(VaccinationCard entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing VaccinationCard observations.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="observations"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VaccinationCard> UpdateAsync(Guid id, string observations, AdminData admin, CancellationToken ct = default);
    }
}
