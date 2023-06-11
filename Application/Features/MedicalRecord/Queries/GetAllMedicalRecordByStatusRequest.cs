using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.MedicalRecord.Queries;

/// <summary>
/// Get MedicalRecord by status request implementation.
/// </summary>
public class GetAllMedicalRecordByStatusRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>>
{
    public int StatusId { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="statusId"></param>
    public GetAllMedicalRecordByStatusRequest(int statusId)
    {
        StatusId = statusId;
    }
}

/// <summary>
/// Get MedicalRecord by status request handler implementation.
/// </summary>
public class GetAllMedicalRecordByStatusRequestHandler : IRequestHandler<GetAllMedicalRecordByStatusRequest,
    ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>>
{
    private readonly ILogger<GetAllMedicalRecordByStatusRequestHandler> Logger;
    private readonly IMedicalRecordReadService MedicalRecordReadService;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="medicalRecordReadService"></param>
    public GetAllMedicalRecordByStatusRequestHandler(ILogger<GetAllMedicalRecordByStatusRequestHandler> logger, 
        IMedicalRecordReadService medicalRecordReadService)
    {
        Logger = logger;
        MedicalRecordReadService = medicalRecordReadService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>> Handle(GetAllMedicalRecordByStatusRequest request, 
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("GetAllMedicalRecordByStatusRequestHandler --> GetAllByStatusasync --> Start");
        
        Guard.Against.Null(request, nameof(request));

        var result = await MedicalRecordReadService.GetAllByStatusAsync(request.StatusId,
            cancellationToken);
        
        Logger.LogInformation("GetAllMedicalRecordByStatusRequestHandler --> GetAllByStatusasync --> End");

        return new ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>(result);
    }
}