using Application.Managers.Abstraction;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionManager.Commands;

public class ApplyForAdoptionRequest : IRequest<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    public Guid AdoptionPendingId { get; private set; }
    public Domain.Entities.Adoption.AdoptionApplication AdoptionApplicationData { get; private set; }
    public UserData UserData { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionPendingId"></param>
    /// <param name="adoptionApplicationData"></param>
    /// <param name="userData"></param>
    public ApplyForAdoptionRequest(Guid adoptionPendingId,
        Domain.Entities.Adoption.AdoptionApplication adoptionApplicationData, UserData userData)
    {
        AdoptionPendingId = adoptionPendingId;
        AdoptionApplicationData = adoptionApplicationData;
        UserData = userData;
    }
}

public class ApplyForAdoptionRequestHandler : IRequestHandler<ApplyForAdoptionRequest,
    ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    private readonly ILogger<ApplyForAdoptionRequestHandler> _logger;
    private readonly IUserReadService _userRead;
    private readonly IAdoptionManager _adoptionManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userRead"></param>
    /// <param name="adoptionManager"></param>
    public ApplyForAdoptionRequestHandler(ILogger<ApplyForAdoptionRequestHandler> logger, IUserReadService userRead,
        IAdoptionManager adoptionManager)
    {
        _logger = logger;
        _userRead = userRead;
        _adoptionManager = adoptionManager;
    }

    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>> Handle(ApplyForAdoptionRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("ApplyForAdoptionRequestHandler --> AddAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.AdoptionPendingId, nameof(request.AdoptionPendingId));
        Guard.Against.Null(request.UserData, nameof(request.UserData));
        Guard.Against.Null(request.AdoptionApplicationData, nameof(request.AdoptionApplicationData));

        var user = await _userRead.GetByIdAsync(request.UserData.Id, cancellationToken);

        request.AdoptionApplicationData.User = user;

        var result = await _adoptionManager.RegisterAdoptionApplication(request.AdoptionPendingId,
            request.AdoptionApplicationData, request.UserData);

        _logger.LogInformation("ApplyForAdoptionRequestHandler --> AddAsync --> End");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionApplication>(result);
    }
}