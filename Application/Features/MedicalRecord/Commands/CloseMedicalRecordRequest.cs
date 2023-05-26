using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.MedicalRecord.Commands
{
    public class CloseMedicalRecordRequest : IRequest<ApiResponse<Domain.Entities.MedicalRecord>>
    {
        public Guid Id { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminData"></param>
        public CloseMedicalRecordRequest(Guid id, AdminData adminData)
        {
            Id = id;
            AdminData = adminData;
        }
    }

    public class CloseMedicalRecordRequestHandler : IRequestHandler<CloseMedicalRecordRequest, ApiResponse<Domain.Entities.MedicalRecord>>
    {
        private readonly ILogger<CloseMedicalRecordRequestHandler> Logger;
        private readonly IMedicalRecordWriteService MedicalRecordWriteService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="medicalRecordWriteService"></param>
        public CloseMedicalRecordRequestHandler(
            ILogger<CloseMedicalRecordRequestHandler> logger,
            IMedicalRecordWriteService medicalRecordWriteService)
        {
            Logger = logger;
            MedicalRecordWriteService = medicalRecordWriteService;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.MedicalRecord>> Handle(CloseMedicalRecordRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("CloseMedicalRecordRequestHandler --> CloseAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.MedicalRecord result = await MedicalRecordWriteService.CloseAsync(request.Id, request.AdminData, cancellationToken);

            Logger.LogInformation("CloseMedicalRecordRequestHandler --> CloseAsync --> End");

            return new ApiResponse<Domain.Entities.MedicalRecord>(result);
        }
    }
}
