using Application.Service.Abstraction;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionPending.Queries;

public class GetAdoptionPendingByIdRequest : IRequest<ApiResponse<Domain.Entities.Adoption.AdoptionPending>>
{
    public Guid Id { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    public GetAdoptionPendingByIdRequest(Guid id)
    {
        Id = id;
    }
}

public class GetAdoptionPendingByIdRequestHandler : IRequestHandler<GetAdoptionPendingByIdRequest,
    ApiResponse<Domain.Entities.Adoption.AdoptionPending>>
{
    private readonly ILogger<GetAdoptionPendingByIdRequestHandler> _logger;
    private readonly IAdoptionPendingReadService _adoptionPendingReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionPendingReadService"></param>
    public GetAdoptionPendingByIdRequestHandler(ILogger<GetAdoptionPendingByIdRequestHandler> logger,
        IAdoptionPendingReadService adoptionPendingReadService)
    {
        _logger = logger;
        _adoptionPendingReadService = adoptionPendingReadService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionPending>> Handle(
        GetAdoptionPendingByIdRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"GetAdoptionPendingByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

        var result = await _adoptionPendingReadService.GetByIdAsync(request.Id, cancellationToken);

        _logger.LogInformation("GetAdoptionPendingByIdRequestHandler --> GetByIdAsync --> End");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionPending>(result);
    }
}