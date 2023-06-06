using Application.Service.Abstraction.Read;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionApplication.Queries;

public class GetAdoptionApplicationByIdRequest : IRequest<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    public Guid Id { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    public GetAdoptionApplicationByIdRequest(Guid id)
    {
        Id = id;
    }
}

public class GetAdoptionApplicationByIdRequestHandler : IRequestHandler<GetAdoptionApplicationByIdRequest,
    ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    private readonly ILogger<GetAdoptionApplicationByIdRequestHandler> _logger;
    private readonly IAdoptionApplicationReadService _adoptionApplicationReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionApplicationReadService"></param>
    public GetAdoptionApplicationByIdRequestHandler(ILogger<GetAdoptionApplicationByIdRequestHandler> logger,
        IAdoptionApplicationReadService adoptionApplicationReadService)
    {
        _logger = logger;
        _adoptionApplicationReadService = adoptionApplicationReadService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>> Handle(
        GetAdoptionApplicationByIdRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"GetAdoptionApplicationByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

        var result = await _adoptionApplicationReadService.GetByIdAsync(request.Id, cancellationToken);

        _logger.LogInformation("GetAdoptionApplicationByIdRequestHandler --> GetByIdAsync --> End");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionApplication>(result);
    }
}