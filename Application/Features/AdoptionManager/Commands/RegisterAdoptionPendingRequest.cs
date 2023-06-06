using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionManager.Commands;

public class RegisterAdoptionPendingRequest : IRequest<ApiResponse<Domain.Entities.Adoption.AdoptionPending>>
{
    public Guid IndividualProceedingId { get; private set; }
    public Domain.Entities.Adoption.AdoptionPending AdoptionPendingData { get; private set; }

    public AdminData AdminData { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="individualProceedingId"></param>
    /// <param name="adoptionPendingData"></param>
    /// <param name="adminData"></param>
    public RegisterAdoptionPendingRequest(Guid individualProceedingId,
        Domain.Entities.Adoption.AdoptionPending adoptionPendingData, AdminData adminData)
    {
        IndividualProceedingId = individualProceedingId;
        AdoptionPendingData = adoptionPendingData;
        AdminData = adminData;
    }
}

public class RegisterAdoptionPendingRequestHandler : IRequestHandler<RegisterAdoptionPendingRequest,
    ApiResponse<Domain.Entities.Adoption.AdoptionPending>>
{
    private readonly ILogger<RegisterAdoptionPendingRequestHandler> _logger;
    private readonly IAdoptionManager _adoptionManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionManager"></param>
    public RegisterAdoptionPendingRequestHandler(ILogger<RegisterAdoptionPendingRequestHandler> logger,
        IAdoptionManager adoptionManager)
    {
        _logger = logger;
        _adoptionManager = adoptionManager;
    }

    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionPending>> Handle(
        RegisterAdoptionPendingRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RegisterAdoptionPendingRequestHandler --> AddAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.AdoptionPendingData, nameof(request.AdoptionPendingData));
        Guard.Against.Null(request.IndividualProceedingId, nameof(request.IndividualProceedingId));

        var result =
            await _adoptionManager.RegisterAdoptionPending(request.IndividualProceedingId, request.AdminData,
                request.AdoptionPendingData);

        _logger.LogInformation("RegisterAdoptionPendingRequestHandler --> AddAsync --> End");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionPending>(result);
    }
}