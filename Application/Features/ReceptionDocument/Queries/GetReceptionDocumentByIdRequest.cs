using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ReceptionDocument.Queries;

/// <summary>
/// Get ReceptionDocument by identifier request implementation.
/// </summary>
public class GetReceptionDocumentByIdRequest : IRequest<ApiResponse<Domain.Entities.ReceptionDocument>>
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
    ApiResponse<Domain.Entities.ReceptionDocument>>
{
    private readonly ILogger<GetReceptionDocumentByIdRequestHandler> _logger;
    private readonly IReceptionDocumentRead _receptionDocumentReadService;
    private const string RECEPTION_DOCUMENT_NOT_FOUND = "ReceptionDocument with id {0} not found.";

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
    public async Task<ApiResponse<Domain.Entities.ReceptionDocument>> Handle(GetReceptionDocumentByIdRequest request, 
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"GetReceptionDocumentByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

        Guard.Against.Null(request, nameof(request));

        Domain.Entities.ReceptionDocument? result = await _receptionDocumentReadService.GetByIdAsync(request.Id, cancellationToken);
        
        if(result is null)
        {
            _logger.LogInformation($"GetReceptionDocumentByIdRequestHandler --> GetByIdAsync({request.Id}) --> Not Found");

            return new ApiResponse<Domain.Entities.ReceptionDocument>()
            {
                Succeeded = false,
                Message = string.Format(RECEPTION_DOCUMENT_NOT_FOUND, request.Id),
                Data = result
            };  
        }

        _logger.LogInformation("GetReceptionDocumentByIdRequestHandler --> GetByIdAsync --> End");

        return new ApiResponse<Domain.Entities.ReceptionDocument>(result);
    }
}