using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Read
{
    public interface IVaccinationCardVaccineReadService : IApplicationServiceBase
    {
        //Task<VaccinationCardVaccine?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get vaccination card vaccine by its identifier with related entities..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<VaccinationCardVaccine?> GetByIdLoadedAsync(Guid id);
    }
}
