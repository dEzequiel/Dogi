using Application.DTOs.VeterinaryManager;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VeterinaryManager.Command
{
    public class CheckMedicalRecordRequest : IRequest<ApiResponse<InvidiualProceedingWithMedicalRecord>>
    {
        public Guid IndividualProceedingId { get; private set; }
        public Guid MedicalRecordId { get; private set; }
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="individualProceedingId"></param>
        /// <param name="medicalRecordId"></param>
        public CheckMedicalRecordRequest(Guid individualProceedingId, Guid medicalRecordId, AdminData adminData)
        {
            IndividualProceedingId = individualProceedingId;
            MedicalRecordId = medicalRecordId;
            AdminData = adminData;
        }

    }

    public class CheckMedicalRecordRequestHandler : IRequestHandler<CheckMedicalRecordRequest, ApiResponse<InvidiualProceedingWithMedicalRecord>>
    {
        private readonly ILogger<CheckMedicalRecordRequestHandler> Logger;
        private readonly IVeterinaryManager VeteriyaryManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="veteriyaryManager"></param>
        public CheckMedicalRecordRequestHandler(ILogger<CheckMedicalRecordRequestHandler> logger, IVeterinaryManager veteriyaryManager)
        {
            Logger = logger;
            VeteriyaryManager = veteriyaryManager;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<InvidiualProceedingWithMedicalRecord>> Handle(CheckMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("CheckMedicalRecordRequestHandler --> CheckAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await VeteriyaryManager.CheckMedicalRecord(request.IndividualProceedingId, request.MedicalRecordId, request.AdminData, cancellationToken);

            Logger.LogInformation("CheckMedicalRecordRequestHandler --> CheckAsync --> End");

            return new ApiResponse<InvidiualProceedingWithMedicalRecord>(result);
        }
    }
}
