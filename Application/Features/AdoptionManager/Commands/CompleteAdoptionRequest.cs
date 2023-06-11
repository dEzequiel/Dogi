using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionManager.Commands;

public class CompleteAdoptionRequest : IRequest<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    public Guid AdoptionApplicationId { get; private set; }
    public bool PickedUp { get; private set; }
    public AdminData AdminData { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionApplicationId"></param>
    /// <param name="pickedUp"></param>
    /// <param name="adminData"></param>
    public CompleteAdoptionRequest(Guid adoptionApplicationId, bool pickedUp, AdminData adminData)
    {
        AdoptionApplicationId = adoptionApplicationId;
        PickedUp = pickedUp;
        AdminData = adminData;
    }
}

public class CompleteAdoptionRequestHandler : IRequestHandler<CompleteAdoptionRequest,
    ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    private readonly ILogger<CompleteAdoptionRequestHandler> _logger;
    private readonly IAdoptionManager _adoptionManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionManager"></param>
    public CompleteAdoptionRequestHandler(ILogger<CompleteAdoptionRequestHandler> logger,
        IAdoptionManager adoptionManager)
    {
        _logger = logger;
        _adoptionManager = adoptionManager;
    }

    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>> Handle(CompleteAdoptionRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("CompleteAdoptionRequestHandler --> CompleteAdoptionApplication --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.NullOrEmpty(request.AdoptionApplicationId, nameof(request.AdoptionApplicationId));
        Guard.Against.Null(request.AdminData, nameof(request.AdminData));

        var result =
            await _adoptionManager.CompleteAdoptionApplication(request.AdoptionApplicationId, request.PickedUp,
                request.AdminData);

        _logger.LogInformation("CompleteAdoptionRequestHandler --> CompleteAdoptionApplication --> End");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionApplication>(result);
    }
}