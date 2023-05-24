using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IVaccinationCardRepository : IRepository<VaccinationCard>
    {
        /// <summary>
        /// Get VaccinationCard by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<VaccinationCard> GetAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add new VaccinationCard.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(VaccinationCard entity, AdminData admin, CancellationToken ct = default);

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
