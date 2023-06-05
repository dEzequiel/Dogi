using Application.Service.Abstraction;
using Application.Service.Abstraction.Read;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AdoptionApplication.Commands;

public class InsertAdoptionApplicationRequest : IRequest<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    public Domain.Entities.Adoption.AdoptionApplication AdoptionApplicationData { get; private set; } = null!;

    public UserData UserData { get; private set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionApplicationData"></param>
    /// <param name="userData"></param>
    public InsertAdoptionApplicationRequest(Domain.Entities.Adoption.AdoptionApplication adoptionApplicationData,
        UserData userData)
    {
        AdoptionApplicationData = adoptionApplicationData;
        UserData = userData;
    }
}

public class InsertAdoptionApplicationRequestHandler : IRequestHandler<InsertAdoptionApplicationRequest,
    ApiResponse<Domain.Entities.Adoption.AdoptionApplication>>
{
    private readonly ILogger<InsertAdoptionApplicationRequestHandler> _logger;
    private readonly IAdoptionApplicationWriteService _adoptionApplicationWriteService;
    private readonly IAdoptionPendingReadService _adoptionPendingReadService;
    private readonly IHousingTypeReadService _housingTypeReadService;
    private readonly IAdoptionApplicationStatusReadService _applicationStatus;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionApplicationWriteService"></param>
    /// <param name="adoptionPendingReadService"></param>
    /// <param name="housingTypeReadService"></param>
    /// <param name="applicationStatus"></param>
    public InsertAdoptionApplicationRequestHandler(ILogger<InsertAdoptionApplicationRequestHandler> logger,
        IAdoptionApplicationWriteService adoptionApplicationWriteService,
        IAdoptionPendingReadService adoptionPendingReadService, IHousingTypeReadService housingTypeReadService,
        IAdoptionApplicationStatusReadService applicationStatus)
    {
        _logger = logger;
        _adoptionApplicationWriteService = adoptionApplicationWriteService;
        _adoptionPendingReadService = adoptionPendingReadService;
        _housingTypeReadService = housingTypeReadService;
        _applicationStatus = applicationStatus;
    }


    /// <inheritdoc />
    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>> Handle(
        InsertAdoptionApplicationRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("InsertAdoptionApplicationRequestHandler --> AddAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.UserData, nameof(request.UserData));
        Guard.Against.Null(request.AdoptionApplicationData, nameof(request.AdoptionApplicationData));

        var housingType =
            await _housingTypeReadService.GetByIdAsync(request.AdoptionApplicationData.HousingTypeId,
                cancellationToken);
        request.AdoptionApplicationData.HousingType = housingType;

        var adoptionPending =
            await _adoptionPendingReadService.GetByIdAsync(request.AdoptionApplicationData.AdoptionPendingId,
                cancellationToken);
        request.AdoptionApplicationData.AdoptionPending = adoptionPending;

        var applicationStatus =
            await _applicationStatus.GetByIdAsync(request.AdoptionApplicationData.AdoptionApplicationStatusId,
                cancellationToken);
        request.AdoptionApplicationData.AdoptionApplicationStatus = applicationStatus;

        var result = await _adoptionApplicationWriteService.AddAsync(request.AdoptionApplicationData, request.UserData);

        _logger.LogInformation("InsertAdoptionApplicationRequestHandler --> AddAsync --> End");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionApplication>(result);
    }
}