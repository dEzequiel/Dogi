using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class VaccinationCardVaccineWrite : IVaccinationCardVaccineWriteService
    {
        private readonly ILogger<VaccinationCardVaccineWrite> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public VaccinationCardVaccineWrite(ILogger<VaccinationCardVaccineWrite> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<VaccinationCardVaccine> AddAsync(VaccinationCardVaccine entity, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("VaccinationCardVaccine --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(entity.VaccinationCardId, nameof(entity.VaccinationCardId));
            Guard.Against.NullOrEmpty(entity.VaccineId, nameof(entity.VaccineId));
            Guard.Against.Null(entity.VaccineStatusId, nameof(entity.VaccineStatusId));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = UnitOfWork.VaccinationCardVaccineRepository;

            await repository.AddAsync(entity, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("VaccinationCardVaccine --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<IEnumerable<VaccinationCardVaccine>> AddRangeAsync(Guid vaccinationCardId, IEnumerable<Guid> vaccinesId, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("VaccinationCardVaccine --> AddRangeAsync --> Start");

            Guard.Against.NullOrEmpty(vaccinationCardId, nameof(vaccinationCardId));
            Guard.Against.NullOrEmpty(vaccinesId, nameof(vaccinesId));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = UnitOfWork.VaccinationCardVaccineRepository;

            var entities = await repository.AddRangeAsync(vaccinationCardId, vaccinesId, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("VaccinationCardVaccine --> AddRangeAsync --> Start");

            return entities;
        }

        ///<inheritdoc />
        public Task<VaccinationCardVaccine> UpdateAsync(Guid id, VaccinationCardVaccine newEntity, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<VaccinationCardVaccine> VaccineAsync(Guid vaccinationCardId, Guid vaccineId, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("VaccinationCardVaccine --> VaccineAsync --> Start");

            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(vaccinationCardId, nameof(vaccinationCardId));
            Guard.Against.NullOrEmpty(vaccineId, nameof(vaccineId));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = UnitOfWork.VaccinationCardVaccineRepository;

            var entity = await repository.VaccineAsync(vaccinationCardId, vaccineId, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("VaccinationCardVaccine --> VaccineAsync --> Start");


            return entity;
        }

        ///<inheritdoc 
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

    }
}
