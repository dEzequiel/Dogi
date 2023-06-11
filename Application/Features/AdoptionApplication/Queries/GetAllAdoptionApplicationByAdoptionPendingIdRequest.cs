using Application.Service.Abstraction.Read;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionApplication.Queries;

public class
    GetAllAdoptionApplicationByAdoptionPendingIdRequest : IRequest<
        ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionApplication>>>
{
    public Guid AdoptionPendingId { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionPendingId"></param>
    public GetAllAdoptionApplicationByAdoptionPendingIdRequest(Guid adoptionPendingId)
    {
        AdoptionPendingId = adoptionPendingId;
    }
}

public class GetAllAdoptionApplicationByAdoptionPendingIdRequestHandler : IRequestHandler<
    GetAllAdoptionApplicationByAdoptionPendingIdRequest,
    ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionApplication>>>
{
    private readonly ILogger<GetAllAdoptionApplicationByAdoptionPendingIdRequestHandler> _logger;
    private readonly IAdoptionApplicationReadService _adoptionApplicationReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionApplicationReadService"></param>
    public GetAllAdoptionApplicationByAdoptionPendingIdRequestHandler(
        ILogger<GetAllAdoptionApplicationByAdoptionPendingIdRequestHandler> logger,
        IAdoptionApplicationReadService adoptionApplicationReadService)
    {
        _logger = logger;
        _adoptionApplicationReadService = adoptionApplicationReadService;
    }

    public async Task<ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionApplication>>> Handle(
        GetAllAdoptionApplicationByAdoptionPendingIdRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            $"GetAllAdoptionApplicationByAdoptionPendingIdRequestHandler --> GetAllByAdoptionPendingIdAsync({request.AdoptionPendingId}) --> Start");

        var result =
            await _adoptionApplicationReadService.GetAllByAdoptionPendingIdAsync(request.AdoptionPendingId,
                cancellationToken);

        _logger.LogInformation(
            "GetAllAdoptionApplicationByAdoptionPendingIdRequestHandler --> GetAllByAdoptionPendingIdAsync --> End");

        return new ApiResponse<IEnumerable<Domain.Entities.Adoption.AdoptionApplication>>(result);
    }
}