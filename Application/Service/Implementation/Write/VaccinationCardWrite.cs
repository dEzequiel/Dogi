using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class VaccinationCardWrite : IVaccinationCardWriteService
    {
        private readonly ILogger<VaccinationCardWrite> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public VaccinationCardWrite(ILogger<VaccinationCardWrite> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<VaccinationCard> AddAsync(VaccinationCard entity, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("VaccinationCardWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = UnitOfWork.VaccinationCardRepository;

            await repository.AddAsync(entity, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("VaccinationCardWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />

        public async Task<VaccinationCard> UpdateAsync(Guid id, string observations, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("VaccinationCardWrite --> AddAsync --> Start");

            Guard.Against.NullOrEmpty(id, nameof(id));
            Guard.Against.NullOrEmpty(observations, nameof(observations));
            Guard.Against.Null(admin, nameof(admin));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));

            var repository = UnitOfWork.VaccinationCardRepository;

            var entity = await repository.UpdateAsync(id, observations, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("VaccinationCardWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


    }
}
