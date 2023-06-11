using Application.Service.Abstraction.Read;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities.Shelter;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.IndividualPro.Queries;

public class GetIndividualProceedingByStatusRequest : IRequest<ApiResponse<IEnumerable<IndividualProceeding>>>
{
    public int Status { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="status"></param>
    public GetIndividualProceedingByStatusRequest(int status)
    {
        Status = status;
    }
}

public class GetIndividualProceedingByStatusRequestHandler : IRequestHandler<GetIndividualProceedingByStatusRequest,
    ApiResponse<IEnumerable<IndividualProceeding>>>
{
    private readonly ILogger<GetIndividualProceedingByStatusRequestHandler> _logger;
    private readonly IIndividualProceedingReadService _individualProceedingReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="individualProceedingReadService"></param>
    public GetIndividualProceedingByStatusRequestHandler(ILogger<GetIndividualProceedingByStatusRequestHandler> logger,
        IIndividualProceedingReadService individualProceedingReadService)
    {
        _logger = logger;
        _individualProceedingReadService = individualProceedingReadService;
    }

    public async Task<ApiResponse<IEnumerable<IndividualProceeding>>> Handle(
        GetIndividualProceedingByStatusRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            $"GetIndividualProceedingByStatusRequestHandler --> GetByStatus({request.Status}) --> Start");

        var result = await _individualProceedingReadService.GetAllByStatusAsync(request.Status, cancellationToken);

        return new ApiResponse<IEnumerable<IndividualProceeding>>(result);
    }
}