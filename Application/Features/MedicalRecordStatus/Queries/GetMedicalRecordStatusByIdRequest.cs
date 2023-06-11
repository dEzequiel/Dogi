using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.MedicalRecordStatus.Queries
{
    /// <summary>
    /// Get MedicalRecordStatus by identifier request implementation.
    /// </summary>
    public class GetMedicalRecordStatusByIdRequest : IRequest<ApiResponse<Domain.Support.MedicalRecordStatus>>
    {
        public int Id { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public GetMedicalRecordStatusByIdRequest(int id)
        {
            Id = id;
        }
    }

    /// <summary>
    /// Get MedicalRecordStatus by identifier handler implementation.
    /// </summary>
    public class GetMedicalRecordStatusByIdRequestHandler : IRequestHandler<GetMedicalRecordStatusByIdRequest,
        ApiResponse<Domain.Support.MedicalRecordStatus>>
    {
        private readonly ILogger<GetMedicalRecordStatusByIdRequestHandler> Logger;
        private readonly IMedicalRecordStatusReadService MedicalRecordStatusReadService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="medicalRecordStatusReadService"></param>
        public GetMedicalRecordStatusByIdRequestHandler(ILogger<GetMedicalRecordStatusByIdRequestHandler> logger,
            IMedicalRecordStatusReadService medicalRecordStatusReadService)
        {
            Logger = logger;
            MedicalRecordStatusReadService = medicalRecordStatusReadService;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Support.MedicalRecordStatus>> Handle(GetMedicalRecordStatusByIdRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"GetMedicalRecordStatusByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Support.MedicalRecordStatus? result = await MedicalRecordStatusReadService.GetByIdAsync(request.Id, cancellationToken);

            Logger.LogInformation("GetMedicalRecordStatusByIdRequestHandler --> GetByIdAsync --> End");

            return new ApiResponse<Domain.Support.MedicalRecordStatus>(result);
        }
    }
}
