using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class PersonBannedInformationWrite : IPersonBannedInformationWriteService
    {
        private readonly ILogger<PersonBannedInformationWrite> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public PersonBannedInformationWrite(ILogger<PersonBannedInformationWrite> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<PersonBannedInformation> AddAsync(PersonBannedInformation entity, AdminData admin, CancellationToken ct = default)
        {
            Logger.LogInformation("PersonBannedInformationWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.NullOrEmpty(admin.Id, nameof(admin.Id));
            Guard.Against.NullOrEmpty(admin.Email, nameof(admin.Email));
            Guard.Against.NullOrEmpty(entity.PersonIdentifierId, nameof(entity.PersonIdentifierId));
            Guard.Against.NullOrEmpty(entity.Observations, nameof(entity.Observations));

            var repository = UnitOfWork.PersonBannedInformationRepository;

            await repository.AddAsync(entity, admin, ct);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("PersonBannedInformationWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
