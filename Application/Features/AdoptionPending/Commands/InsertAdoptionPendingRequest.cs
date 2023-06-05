using Application.Service.Abstraction.Read;
using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionPending.Commands;

public class InsertAdoptionPendingRequest : IRequest<ApiResponse<Domain.Entities.Adoption.AdoptionPending>>
{
    public Domain.Entities.Adoption.AdoptionPending AdoptionPendingData { get; private set; } = null;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionPendingData"></param>
    public InsertAdoptionPendingRequest(Domain.Entities.Adoption.AdoptionPending adoptionPendingData)
    {
        AdoptionPendingData = adoptionPendingData;
    }
}

public class InsertAdoptionPendingRequestHandler : IRequestHandler<InsertAdoptionPendingRequest,
    ApiResponse<Domain.Entities.Adoption.AdoptionPending>>
{
    private readonly ILogger<InsertAdoptionPendingRequestHandler> _logger;
    private readonly IAdoptionPendingWriteService _adoptionPending;
    private readonly IIndividualProceedingReadService _individualProceedingReadService;
    private readonly IAdoptionPendingStatusReadService _pendingStatusReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionPending"></param>
    /// <param name="individualProceedingReadService"></param>
    /// <param name="pendingStatusReadService"></param>
    public InsertAdoptionPendingRequestHandler(ILogger<InsertAdoptionPendingRequestHandler> logger,
        IAdoptionPendingWriteService adoptionPending, IIndividualProceedingReadService individualProceedingReadService,
        IAdoptionPendingStatusReadService pendingStatusReadService)
    {
        _logger = logger;
        _adoptionPending = adoptionPending;
        _individualProceedingReadService = individualProceedingReadService;
        _pendingStatusReadService = pendingStatusReadService;
    }

    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionPending>> Handle(
        InsertAdoptionPendingRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("InsertAdoptionApplicationRequestHandler --> AddAsync --> Start");

        var individualProceeding =
            await _individualProceedingReadService.GetByIdAsync(request.AdoptionPendingData.IndividualProceedingId);
        request.AdoptionPendingData.IndividualProceedingId = individualProceeding.Id;

        var adoptionPendingStatus =
            await _pendingStatusReadService.GetByIdAsync(request.AdoptionPendingData.AdoptionPendingStatusId);
        request.AdoptionPendingData.AdoptionPendingStatusId = adoptionPendingStatus.Id;

        var result = await _adoptionPending.AddAsync(request.AdoptionPendingData, cancellationToken);

        _logger.LogInformation("InsertAdoptionApplicationRequestHandler --> AddAsync --> Start");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionPending>(result);
    }
}