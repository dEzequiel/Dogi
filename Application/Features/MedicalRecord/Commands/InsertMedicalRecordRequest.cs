using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.MedicalRecord.Comamnds
{
    /// <summary>
    /// Insert MedicalRecord request implementation.
    /// </summary>
    public class InsertMedicalRecordRequest : IRequest<ApiResponse<Domain.Entities.MedicalRecord>>
    {
        public Domain.Entities.MedicalRecord MedicalRecordData { get; private set; } = null!;
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="medicalRecordData"></param>
        /// <param name="adminData"></param>
        public InsertMedicalRecordRequest(Domain.Entities.MedicalRecord medicalRecordData, AdminData adminData)
        {
            MedicalRecordData = medicalRecordData;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Insert MedicalRecord handler implementation.
    /// </summary>
    public class InsertMedicalRecordRequestHandler : IRequestHandler<InsertMedicalRecordRequest, ApiResponse<Domain.Entities.MedicalRecord>>
    {
        private readonly ILogger<InsertMedicalRecordRequestHandler> Logger;
        private readonly IMedicalRecordWriteService MedicalRecordWriteService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentWriteService"></param>
        public InsertMedicalRecordRequestHandler(ILogger<InsertMedicalRecordRequestHandler> logger, IMedicalRecordWriteService medicalRecordWriteService)
        {
            Logger = logger;
            MedicalRecordWriteService = medicalRecordWriteService;
        }

        public async Task<ApiResponse<Domain.Entities.MedicalRecord>> Handle(InsertMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertMedicalRecordRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.MedicalRecord result = await MedicalRecordWriteService.AddAsync(request.MedicalRecordData, request.AdminData, cancellationToken);

            Logger.LogInformation("InsertMedicalRecordRequestHandler --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.MedicalRecord>(result);
        }
    }
}
