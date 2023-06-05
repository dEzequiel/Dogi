using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities.Shelter;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.IndividualPro.Commands;

public class CloseIndividualProceedingRequest : IRequest<ApiResponse<IndividualProceeding>>
{
    public Guid Id { get; private set; }
    public AdminData AdminData { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="adminData"></param>
    public CloseIndividualProceedingRequest(Guid id, AdminData adminData)
    {
        Id = id;
        AdminData = adminData;
    }
}

public class CloseIndividualProceedingRequestHandler : IRequestHandler<CloseIndividualProceedingRequest,
    ApiResponse<IndividualProceeding>>
{
    private readonly ILogger<CloseIndividualProceedingRequestHandler> _logger;
    private readonly IIndividualProceedingWriteService _individualProceedingWrite;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="individualProceedingWrite"></param>
    public CloseIndividualProceedingRequestHandler(
        ILogger<CloseIndividualProceedingRequestHandler> logger,
        IIndividualProceedingWriteService individualProceedingWrite)
    {
        _logger = logger;
        _individualProceedingWrite = individualProceedingWrite;
    }

    public async Task<ApiResponse<IndividualProceeding>> Handle(CloseIndividualProceedingRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("UpdateIndividualProceedingStatusRequestHandler --> AdoptAsync --> Start");

        var result = await _individualProceedingWrite.CloseAsync(request.Id, request.AdminData, cancellationToken);

        _logger.LogInformation("UpdateIndividualProceedingStatusRequestHandler --> AdoptAsync --> End");

        return new ApiResponse<IndividualProceeding>(result);
    }
}