using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.RoleUser.Commands;

/// <summary>
/// Register role user request implementation.
/// </summary>
public class AssigneUserToRoleRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.Authorization.RoleUser>>>
{
    public Guid UserId { get; private set; }
    public IEnumerable<int> RolesIds { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="rolesIds"></param>
    public AssigneUserToRoleRequest(Guid userId, IEnumerable<int> rolesIds)
    {
        UserId = userId;
        RolesIds = rolesIds;
    }
}

/// <summary>
/// Register role user request handler implementation.
/// </summary>
public class AssigneUserToRoleRequestHandler : IRequestHandler<AssigneUserToRoleRequest,
    ApiResponse<IEnumerable<Domain.Entities.Authorization.RoleUser>>>
{
    private readonly ILogger<AssigneUserToRoleRequestHandler> Logger;
    private readonly IRoleUserWriteService RoleUserWriteService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="roleUserWriteService"></param>
    public AssigneUserToRoleRequestHandler(ILogger<AssigneUserToRoleRequestHandler> logger,
        IRoleUserWriteService roleUserWriteService)
    {
        Logger = logger;
        RoleUserWriteService = roleUserWriteService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<IEnumerable<Domain.Entities.Authorization.RoleUser>>> Handle(
        AssigneUserToRoleRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("AssigneUserToRoleRequestHandler --> AddAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.UserId, nameof(request.UserId));
        Guard.Against.NullOrEmpty(request.RolesIds, nameof(request.RolesIds));

        var result = await RoleUserWriteService.AddAsync(request.UserId, request.RolesIds,
            cancellationToken);

        Logger.LogInformation("AssigneUserToRoleRequestHandler --> AddAsync --> End");

        return new ApiResponse<IEnumerable<Domain.Entities.Authorization.RoleUser>>(result);
    }
}