using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read
{
    public class VaccinationCardVaccineRead : IVaccinationCardVaccineReadService
    {
        private readonly ILogger<VaccinationCardVaccineRead> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public VaccinationCardVaccineRead(ILogger<VaccinationCardVaccineRead> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<VaccinationCardVaccine?> GetByIdLoadedAsync(Guid id)
        {
            Logger.LogInformation($"VaccinationCardVaccineRead --> GetByIdLoadedAsync({id}) --> Start");

            Guard.Against.Null(id, nameof(id));

            var repository = UnitOfWork.VaccinationCardVaccineRepository;

            var vaccinationCardVaccine = await repository.GetLoadedAsync(id);

            Logger.LogInformation($"VaccinationCardVaccineRead --> GetByIdLoadedAsync({id}) --> End");

            return vaccinationCardVaccine;
        }


        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
