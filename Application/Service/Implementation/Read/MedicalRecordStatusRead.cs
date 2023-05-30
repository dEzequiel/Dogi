using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Domain.Support;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read
{
    public class MedicalRecordStatusRead : IMedicalRecordStatusReadService
    {
        private readonly ILogger<MedicalRecordStatusRead> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public MedicalRecordStatusRead(ILogger<MedicalRecordStatusRead> logger, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<MedicalRecordStatus> GetByIdAsync(int id, CancellationToken ct = default)
        {
            Logger.LogInformation("MedicalRecordStatusRead --> GetByIdAsync({id}) --> Start");

            Guard.Against.Null(id, nameof(id));

            var repository = UnitOfWork.MedicalRecordStatusRepository;

            var status = await repository.GetAsync(id, ct);

            Logger.LogInformation("MedicalRecordStatusRead --> GetByIdAsync({id}) --> eND");

            return status;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

    }
}
