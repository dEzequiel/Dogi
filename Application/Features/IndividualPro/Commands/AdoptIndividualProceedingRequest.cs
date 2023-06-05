using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities.Shelter;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.IndividualPro.Commands;

public class UpdateIndividualProceedingStatusRequest : IRequest<ApiResponse<IndividualProceeding>>
{
    public Guid Id { get; private set; }
    public AdminData AdminData { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="adminData"></param>
    public UpdateIndividualProceedingStatusRequest(Guid id, AdminData adminData)
    {
        Id = id;
        AdminData = adminData;
    }
}

public class UpdateIndividualProceedingStatusRequestHandler : IRequestHandler<UpdateIndividualProceedingStatusRequest,
    ApiResponse<IndividualProceeding>>
{
    private readonly ILogger<UpdateIndividualProceedingStatusRequestHandler> _logger;
    private readonly IIndividualProceedingWriteService _individualProceedingWrite;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="individualProceedingWrite"></param>
    public UpdateIndividualProceedingStatusRequestHandler(
        ILogger<UpdateIndividualProceedingStatusRequestHandler> logger,
        IIndividualProceedingWriteService individualProceedingWrite)
    {
        _logger = logger;
        _individualProceedingWrite = individualProceedingWrite;
    }

    public async Task<ApiResponse<IndividualProceeding>> Handle(UpdateIndividualProceedingStatusRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("UpdateIndividualProceedingStatusRequestHandler --> AdoptAsync --> Start");

        var result = await _individualProceedingWrite.AdoptAsync(request.Id, request.AdminData);

        _logger.LogInformation("UpdateIndividualProceedingStatusRequestHandler --> AdoptAsync --> End");

        return new ApiResponse<IndividualProceeding>(result);
    }
}