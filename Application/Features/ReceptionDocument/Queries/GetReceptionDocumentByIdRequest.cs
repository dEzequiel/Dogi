using Application.DTOs.ReceptionDocument;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ReceptionDocument.Queries;

/// <summary>
/// Get ReceptionDocument by identifier request implementation.
/// </summary>
public class GetReceptionDocumentByIdRequest : IRequest<ApiResponse<ReceptionDocumentForGet>>
{
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    public GetReceptionDocumentByIdRequest(Guid id) => this.Id = id;
}

/// <summary>
/// Get ReceptionDocument by identifier handler implementation.
/// </summary>
public class GetReceptionDocumentByIdRequestHandler : IRequestHandler<GetReceptionDocumentByIdRequest,
    ApiResponse<ReceptionDocumentForGet>>
{
    private readonly ILogger<GetReceptionDocumentByIdRequestHandler> _logger;
    private readonly IReceptionDocumentRead _receptionDocumentReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="receptionDocumentReadService"></param>
    public GetReceptionDocumentByIdRequestHandler(ILogger<GetReceptionDocumentByIdRequestHandler> logger, 
        IReceptionDocumentRead receptionDocumentReadService)
    {
        _logger = Guard.Against.Null(logger, nameof(logger));
        _receptionDocumentReadService = Guard.Against.Null(receptionDocumentReadService, nameof(receptionDocumentReadService));
    }

    ///<inheritdoc/>
    public async Task<ApiResponse<ReceptionDocumentForGet>> Handle(GetReceptionDocumentByIdRequest request, 
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"GetReceptionDocumentByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

        Guard.Against.Null(request, nameof(request));

        ReceptionDocumentForGet result = await _receptionDocumentReadService.GetByIdAsync(request.Id);
        
        _logger.LogInformation("GetReceptionDocumentByIdRequestHandler --> GetByIdAsync --> End");

        return new ApiResponse<ReceptionDocumentForGet>(result);
    }
}