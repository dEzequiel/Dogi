using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.MedicalRecord.Commands
{
    /// <summary>
    /// Check MedicalRecord request implementation.
    /// </summary>
    public class CheckMedicalRecordRequest : IRequest<ApiResponse<Domain.Entities.MedicalRecord>>
    {
        public Domain.Entities.MedicalRecord MedicalRecordData { get; private set; } = null!;
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="medicalRecordData"></param>
        /// <param name="adminData"></param>
        public CheckMedicalRecordRequest(Domain.Entities.MedicalRecord medicalRecordData, AdminData adminData)
        {
            MedicalRecordData = medicalRecordData;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Check MedicalRecord handler implementation.
    /// </summary>
    public class CheckMedicalRecordRequestHandler : IRequestHandler<CheckMedicalRecordRequest, ApiResponse<Domain.Entities.MedicalRecord>>
    {
        private readonly ILogger<CheckMedicalRecordRequestHandler> Logger;
        private readonly IMedicalRecordWriteService MedicalRecordWriteService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="medicalRecordWriteService"></param>
        public CheckMedicalRecordRequestHandler(ILogger<CheckMedicalRecordRequestHandler> logger, IMedicalRecordWriteService medicalRecordWriteService)
        {
            Logger = logger;
            MedicalRecordWriteService = medicalRecordWriteService;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.MedicalRecord>> Handle(CheckMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("CheckMedicalRecordRequestHandler --> CheckAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.MedicalRecord result = await MedicalRecordWriteService.CheckAsync(request.MedicalRecordData, request.AdminData, cancellationToken);

            Logger.LogInformation("CheckMedicalRecordRequestHandler --> CheckAsync --> End");

            return new ApiResponse<Domain.Entities.MedicalRecord>(result);
        }
    }
}


