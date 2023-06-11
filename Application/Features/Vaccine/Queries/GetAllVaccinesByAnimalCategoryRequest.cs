using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Vaccine.Queries;

public class GetAllVaccinesByAnimalCategoryRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.Vaccine>>>
{
    public int AnimalCategoryId { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="animalCategoryId"></param>
    public GetAllVaccinesByAnimalCategoryRequest(int animalCategoryId)
    {
        AnimalCategoryId = animalCategoryId;
    }
}

public class GetAllVaccinesByAnimalCategoryRequestHandler : IRequestHandler<GetAllVaccinesByAnimalCategoryRequest,
    ApiResponse<IEnumerable<Domain.Entities.Vaccine>>>
{
    private readonly ILogger<GetAllVaccinesByAnimalCategoryRequestHandler> _logger;
    private readonly IVaccineReadService _vaccineReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="vaccineReadService"></param>
    public GetAllVaccinesByAnimalCategoryRequestHandler(ILogger<GetAllVaccinesByAnimalCategoryRequestHandler> logger,
        IVaccineReadService vaccineReadService)
    {
        _logger = logger;
        _vaccineReadService = vaccineReadService;
    }

    public async Task<ApiResponse<IEnumerable<Domain.Entities.Vaccine>>> Handle(
        GetAllVaccinesByAnimalCategoryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "GetAllVaccinesByAnimalCategoryRequestHandler --> GetAllByAnimalCategoryAsync --> Start");

        Guard.Against.Null(request, nameof(request));

        var result = await _vaccineReadService.GetAllByAnimalCategory(request.AnimalCategoryId,
            cancellationToken);

        _logger.LogInformation("GetAllVaccinesByAnimalCategoryRequestHandler --> GetAllByAnimalCategoryAsync --> End");

        return new ApiResponse<IEnumerable<Domain.Entities.Vaccine>>(result);
    }
}