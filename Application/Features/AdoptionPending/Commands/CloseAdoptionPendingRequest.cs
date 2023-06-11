using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionPending.Commands;

public class CloseAdoptionPendingRequest : IRequest<ApiResponse<bool>>
{
    public Guid AdoptionPendingId { get; private set; }
    public AdminData AdminData { get; private set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionPendingId"></param>
    /// <param name="adminData"></param>
    public CloseAdoptionPendingRequest(Guid adoptionPendingId, AdminData adminData)
    {
        AdoptionPendingId = adoptionPendingId;
        AdminData = adminData;
    }
}

public class CloseAdoptionPendingRequestHandler : IRequestHandler<CloseAdoptionPendingRequest, ApiResponse<bool>>
{
    private readonly ILogger<CloseAdoptionPendingRequestHandler> _logger;
    private readonly IAdoptionPendingWriteService _adoptionPending;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionPending"></param>
    public CloseAdoptionPendingRequestHandler(ILogger<CloseAdoptionPendingRequestHandler> logger,
        IAdoptionPendingWriteService adoptionPending)
    {
        _logger = logger;
        _adoptionPending = adoptionPending;
    }

    public async Task<ApiResponse<bool>> Handle(CloseAdoptionPendingRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("CloseAdoptionPendingRequestHandler --> CloseAdoptionAsync --> Start");

        var result = await _adoptionPending.CloseAdoptionAsync(request.AdoptionPendingId, request.AdminData,
            cancellationToken);

        _logger.LogInformation("CloseAdoptionPendingRequestHandler --> CloseAdoptionAsync --> End");

        return new ApiResponse<bool>(result);
    }
}