using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Write
{
    public interface IVaccinationCardVaccineWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add new VaccinationCardVaccine.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VaccinationCardVaccine> AddAsync(VaccinationCardVaccine entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Add collection of VaccinationCardVaccine.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccinesId"></param>
        /// <param name=""></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<VaccinationCardVaccine>> AddRangeAsync(Guid vaccinationCardId, IEnumerable<Guid> vaccinesId, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Set VaccinationCardVaccine vaccine as done.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccineId"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VaccinationCardVaccine> VaccineAsync(Guid vaccinationCardId, Guid vaccineId, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing VaccinationCardVaccine.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEntity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<VaccinationCardVaccine> UpdateAsync(Guid id, VaccinationCardVaccine newEntity, AdminData admin, CancellationToken ct = default);
    }
}
