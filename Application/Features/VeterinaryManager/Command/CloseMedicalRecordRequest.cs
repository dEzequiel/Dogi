using Application.DTOs.VeterinaryManager;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VeterinaryManager.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class CloseMedicalRecordRequest : IRequest<ApiResponse<IndividualProceedingWithMedicalRecord>>
    {
        public Guid MedicalRecordId { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <param name="adminData"></param>
        public CloseMedicalRecordRequest(Guid medicalRecordId, AdminData adminData)
        {
            MedicalRecordId = medicalRecordId;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CloseMedicalRecordRequestHandler : IRequestHandler<CloseMedicalRecordRequest, ApiResponse<IndividualProceedingWithMedicalRecord>>
    {
        private readonly ILogger<CloseMedicalRecordRequestHandler> Logger;
        private readonly IVeterinaryManager VeterinaryManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="veterinaryManager"></param>
        public CloseMedicalRecordRequestHandler(ILogger<CloseMedicalRecordRequestHandler> logger, IVeterinaryManager veterinaryManager)
        {
            Logger = logger;
            VeterinaryManager = veterinaryManager;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IndividualProceedingWithMedicalRecord>> Handle(CloseMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"CloseMedicalRecordRequestHandler --> Handle --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await VeterinaryManager.CloseMedicalRecord(request.MedicalRecordId, request.AdminData, cancellationToken);

            Logger.LogInformation($"CloseMedicalRecordRequestHandler --> Handle --> End");

            return new ApiResponse<IndividualProceedingWithMedicalRecord>(result);
        }
    }
}
