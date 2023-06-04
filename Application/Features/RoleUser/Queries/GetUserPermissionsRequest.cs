using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.RoleUser.Queries;

public class GetUserPermissionsRequest : IRequest<ApiResponse<HashSet<string>>>
{
    public Guid UserId { get; private set; }

    public GetUserPermissionsRequest(Guid userId)
    {
        UserId = userId;
    }
}

public class GetUserPermissionsRequestHandler : IRequestHandler<GetUserPermissionsRequest, ApiResponse<HashSet<string>>>
{
    private readonly ILogger<GetUserPermissionsRequestHandler> Logger;
    private readonly IRoleUserReadService RoleUserReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="roleUserReadService"></param>
    public GetUserPermissionsRequestHandler(ILogger<GetUserPermissionsRequestHandler> logger,
        IRoleUserReadService roleUserReadService)
    {
        Logger = logger;
        RoleUserReadService = roleUserReadService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<HashSet<string>>> Handle(GetUserPermissionsRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("GetUserPermissionsRequestHandler --> GetPermissionsAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.NullOrEmpty(request.UserId, nameof(request.UserId));

        var result = await RoleUserReadService.GetPermissionsAsync(request.UserId);

        Logger.LogInformation("GetUserPermissionsRequestHandler --> GetPermissionsAsync --> End");

        return new ApiResponse<HashSet<string>>(result);
    }
}