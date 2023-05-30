using Application.DTOs.VeterinaryManager;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VeterinaryManager.Command
{
    public class CheckMedicalRecordRequest : IRequest<ApiResponse<IndividualProceedingWithMedicalRecord>>
    {
        public Guid MedicalRecordId { get; private set; }
        public string? Observations { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <param name="observations"></param>
        /// <param name="adminData"></param>
        public CheckMedicalRecordRequest(Guid medicalRecordId, string? observations, AdminData adminData)
        {
            MedicalRecordId = medicalRecordId;
            Observations = observations;
            AdminData = adminData;

        }

    }

    public class CheckMedicalRecordRequestHandler : IRequestHandler<CheckMedicalRecordRequest, ApiResponse<IndividualProceedingWithMedicalRecord>>
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
        public async Task<ApiResponse<IndividualProceedingWithMedicalRecord>> Handle(CheckMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("CheckMedicalRecordRequestHandler --> CheckAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await VeteriyaryManager.CheckMedicalRecord(request.MedicalRecordId, request.Observations, request.AdminData, cancellationToken);

            Logger.LogInformation("CheckMedicalRecordRequestHandler --> CheckAsync --> End");

            return new ApiResponse<IndividualProceedingWithMedicalRecord>(result);
        }
    }
}
