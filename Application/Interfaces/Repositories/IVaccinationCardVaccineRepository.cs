using Application.DTOs.VeterinaryManager;
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
        /// Add collection of VaccinationCardVaccine.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccinesId"></param>
        /// <param name=""></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<VaccinationCardVaccine>> AddRangeAsync(Guid vaccinationCardId, IEnumerable<Guid> vaccinesId, int vaccineStatusId, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Apply vaccine and update status..
        /// </summary>
        /// <param name="vaccineCardId"></param>
        /// <param name="vaccineId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<VaccinationCardVaccine>> VaccineAsync(Guid vaccineCardId, VaccinesToComplish vaccinesIds, AdminData admin, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get VaccinationCardVaccine by id with loaded data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VaccinationCardVaccine> GetLoadedAsync(Guid id, CancellationToken ct = default);
    }
}
