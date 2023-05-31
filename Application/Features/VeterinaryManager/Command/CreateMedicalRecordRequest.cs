using Application.DTOs.VeterinaryManager;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VeterinaryManager.Command
{
    public class CreateMedicalRecordRequest : IRequest<ApiResponse<IndividualProceedingWithMedicalRecord>>
    {

        public Guid IndividualProceedingId { get; private set; }
        public Domain.Entities.MedicalRecord medicalRecord { get; private set; }
        public IEnumerable<Guid>? VaccinesIds { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="individualProceedingId"></param>
        /// <param name="medicalRecord"></param>
        /// <param name="vaccinesIds"></param>
        /// <param name="adminData"></param>
        public CreateMedicalRecordRequest(
            Guid individualProceedingId,
            Domain.Entities.MedicalRecord medicalRecord,
            IEnumerable<Guid>? vaccinesIds,
            AdminData adminData)
        {
            IndividualProceedingId = individualProceedingId;
            this.medicalRecord = medicalRecord;
            VaccinesIds = vaccinesIds;
            AdminData = adminData;
        }
    }

    public class CreateMedicalRecordRequestHandler : IRequestHandler<CreateMedicalRecordRequest, ApiResponse<IndividualProceedingWithMedicalRecord>>
    {
        private readonly ILogger<CreateMedicalRecordRequestHandler> Logger;
        private readonly IVeterinaryManager VeterinaryManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="veterinaryManager"></param>
        public CreateMedicalRecordRequestHandler(ILogger<CreateMedicalRecordRequestHandler> logger, IVeterinaryManager veterinaryManager)
        {
            Logger = logger;
            VeterinaryManager = veterinaryManager;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IndividualProceedingWithMedicalRecord>> Handle(CreateMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"CloseMedicalRecordRequestHandler --> Handle --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await VeterinaryManager.CreateMedicalRecord(request.IndividualProceedingId, request.medicalRecord, request.VaccinesIds, request.AdminData, cancellationToken);

            Logger.LogInformation($"CloseMedicalRecordRequestHandler --> Handle --> End");

            return new ApiResponse<IndividualProceedingWithMedicalRecord>(result);
        }
    }
}
