using Application.Service.Abstraction.Read;
using Application.Service.Implementation.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.MedicalRecord.Queries;

/// <summary>
/// Get all MedicalRecord request implementation.
/// </summary>
public class GetAllMedicalRecordRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>>
{
    public GetAllMedicalRecordRequest()
    {
    }
}

/// <summary>
/// Get all MedicalRecord request handler implementation.
/// </summary>
public class GetAllMedicalRecordRequestHandler : IRequestHandler<GetAllMedicalRecordRequest,
    ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>>
{
    private readonly ILogger<GetAllMedicalRecordRequestHandler> Logger;
    private IMedicalRecordReadService MedicalRecordReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="medicalRecordReadService"></param>
    public GetAllMedicalRecordRequestHandler(ILogger<GetAllMedicalRecordRequestHandler> logger,
        IMedicalRecordReadService medicalRecordReadService)
    {
        Logger = logger;
        MedicalRecordReadService = medicalRecordReadService;
    }
    
    ///<inheritdoc />
    public async Task<ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>> Handle(GetAllMedicalRecordRequest request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("GetAllMedicalRecordRequestHandler --> GetAllAsync --> Start");
        
        Guard.Against.Null(request, nameof(request));

        var result = await MedicalRecordReadService.GetAllAsync();
        
        Logger.LogInformation("GetAllMedicalRecordRequestHandler --> GetAllAsync --> End");

        return new ApiResponse<IEnumerable<Domain.Entities.MedicalRecord>>(result);    
    }
}