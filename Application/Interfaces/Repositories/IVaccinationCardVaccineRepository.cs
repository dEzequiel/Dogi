using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IVaccinationCardVaccineRepository : IRepository<VaccinationCardVaccine>
    {
        /// <summary>
        /// Add new VaccinationCardVaccine.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(VaccinationCardVaccine entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Apply vaccine and update status..
        /// </summary>
        /// <param name="vaccineCardId"></param>
        /// <param name="vaccineId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<VaccinationCardVaccine> VaccineAsync(Guid vaccineCardId, Guid vaccineId, AdminData admin, CancellationToken cancellationToken = default);
    }
}
