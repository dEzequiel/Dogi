using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Person.Queries;

/// <summary>
/// Get Person by user id request implementation.
/// </summary
public class GetPersonByUserIdRequest : IRequest<ApiResponse<Domain.Entities.Shelter.Person>>
{
    public Guid UserId { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userId"></param>
    public GetPersonByUserIdRequest(Guid userId)
    {
        UserId = userId;
    }
}

/// <summary>
/// Get Person by user id request handler implementation.
/// </summary>
public class GetPersonByUserIdRequestHandler : IRequestHandler<GetPersonByUserIdRequest,
    ApiResponse<Domain.Entities.Shelter.Person>>
{
    private readonly ILogger<GetPersonByUserIdRequestHandler> Logger;
    private readonly IPersonReadService PersonReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="personReadService"></param>
    public GetPersonByUserIdRequestHandler(ILogger<GetPersonByUserIdRequestHandler> logger,
        IPersonReadService personReadService)
    {
        Logger = logger;
        PersonReadService = personReadService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<Domain.Entities.Shelter.Person>> Handle(GetPersonByUserIdRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("GetPersonByUserIdRequestHandler --> GetByUserIdAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.NullOrEmpty(request.UserId, nameof(request.UserId));

        var result = await PersonReadService.GetByUserIdAsync(request.UserId);

        Logger.LogInformation("GetUserPermissionsRequestHandler --> GetPermissionsAsync --> End");

        return new ApiResponse<Domain.Entities.Shelter.Person>(result);
    }
}