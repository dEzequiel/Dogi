using Application.Service.Abstraction;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionPending.Queries;

public class
    GetAllAdoptionPendingsByStatusIdRequest : IRequest<
        ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionPending>>>
{
    public int Status { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="status"></param>
    public GetAllAdoptionPendingsByStatusIdRequest(int status)
    {
        Status = status;
    }
}

public class GetAllAdoptionPendingsByStatusIdRequestHandler : IRequestHandler<GetAllAdoptionPendingsByStatusIdRequest,
    ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionPending>>>
{
    private readonly ILogger<GetAllAdoptionPendingsByStatusIdRequestHandler> _logger;
    private readonly IAdoptionPendingReadService _adoptionPendingReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionPendingReadService"></param>
    public GetAllAdoptionPendingsByStatusIdRequestHandler(
        ILogger<GetAllAdoptionPendingsByStatusIdRequestHandler> logger,
        IAdoptionPendingReadService adoptionPendingReadService)
    {
        _logger = logger;
        _adoptionPendingReadService = adoptionPendingReadService;
    }

    public async Task<ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionPending>>> Handle(
        GetAllAdoptionPendingsByStatusIdRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"GetAdoptionPendingByIdRequestHandler --> GetByIdAsync({request.Status}) --> Start");

        var result = await _adoptionPendingReadService.GetAllByStatusIdAsync(request.Status, cancellationToken);

        _logger.LogInformation("GetAdoptionPendingByIdRequestHandler --> GetByIdAsync --> End");

        return new ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionPending>>(result);
    }
}