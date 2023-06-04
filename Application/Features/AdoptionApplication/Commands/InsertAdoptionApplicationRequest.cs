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
    private readonly ILogger<InsertAdoptionApplicationRequestHandler> Logger;
    private readonly IAdoptionApplicationWriteService AdoptionApplicationWriteService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="adoptionApplicationWriteService"></param>
    public InsertAdoptionApplicationRequestHandler(ILogger<InsertAdoptionApplicationRequestHandler> logger,
        IAdoptionApplicationWriteService adoptionApplicationWriteService)
    {
        Logger = logger;
        AdoptionApplicationWriteService = adoptionApplicationWriteService;
    }

    /// <inheritdoc />
    public async Task<ApiResponse<Domain.Entities.Adoption.AdoptionApplication>> Handle(
        InsertAdoptionApplicationRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("InsertAdoptionApplicationRequestHandler --> AddAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.UserData, nameof(request.UserData));
        Guard.Against.Null(request.AdoptionApplicationData, nameof(request.AdoptionApplicationData));

        var result = await AdoptionApplicationWriteService.AddAsync(request.AdoptionApplicationData, request.UserData);

        Logger.LogInformation("InsertAdoptionApplicationRequestHandler --> AddAsync --> End");

        return new ApiResponse<Domain.Entities.Adoption.AdoptionApplication>(result);
    }
}