using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionApplication.Commands;

public class CompleteAdoptionApplicationRequest : IRequest<ApiResponse<bool>>
{
    public Guid AdoptionApplicationId { get; private set; }
    public AdminData AdminData { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionApplicationId"></param>
    /// <param name="adminData"></param>
    public CompleteAdoptionApplicationRequest(Guid adoptionApplicationId, AdminData adminData)
    {
        AdoptionApplicationId = adoptionApplicationId;
        AdminData = adminData;
    }
}

public class
    CompleteAdoptionApplicationRequestHandler : IRequestHandler<CompleteAdoptionApplicationRequest, ApiResponse<bool>>
{
    private readonly ILogger<CompleteAdoptionApplicationRequestHandler> _logger;
    private readonly IAdoptionApplicationWriteService _adoptionApplicationWriteService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionApplicationWriteService"></param>
    public CompleteAdoptionApplicationRequestHandler(ILogger<CompleteAdoptionApplicationRequestHandler> logger,
        IAdoptionApplicationWriteService adoptionApplicationWriteService)
    {
        _logger = logger;
        _adoptionApplicationWriteService = adoptionApplicationWriteService;
    }

    public async Task<ApiResponse<bool>> Handle(CompleteAdoptionApplicationRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            $"GetAdoptionApplicationByIdRequestHandler --> GetByIdAsync({request.AdoptionApplicationId}) --> Start");

        var result = await _adoptionApplicationWriteService.CompleteApplicationAsync(
            request.AdoptionApplicationId, request.AdminData, cancellationToken);

        _logger.LogInformation("GetAdoptionApplicationByIdRequestHandler --> GetByIdAsync --> End");

        return new ApiResponse<bool>(result);
    }
}