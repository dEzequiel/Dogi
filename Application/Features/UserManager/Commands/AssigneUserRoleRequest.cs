using Application.DTOs.UserManager;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.UserManager.Commands;

/// <summary>
/// Assign user role request implementation.
/// </summary>
public class AssigneUserRoleRequest : IRequest<ApiResponse<UserWithPermissions>>
{
    public UserWithRoles UserWithRoles { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userWithRoles"></param>
    public AssigneUserRoleRequest(UserWithRoles userWithRoles)
    {
        UserWithRoles = userWithRoles;
    }
}

/// <summary>
/// Assign user role request handler implementation.
/// </summary>
public class AssigneUserRoleRequestHandler : IRequestHandler<AssigneUserRoleRequest, ApiResponse<UserWithPermissions>>
{
    private readonly ILogger<AssigneUserRoleRequest> Logger;
    private readonly IUserManager UserManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userManager"></param>
    public AssigneUserRoleRequestHandler(ILogger<AssigneUserRoleRequest> logger, IUserManager userManager)
    {
        Logger = logger;
        UserManager = userManager;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<UserWithPermissions>> Handle(AssigneUserRoleRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("AssigneUserRoleRequestHandler --> Handle --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.UserWithRoles, nameof(request.UserWithRoles));


        var result = await UserManager.AssigneRole(request.UserWithRoles, cancellationToken);

        Logger.LogInformation("AssigneUserRoleRequestHandler --> Handle --> End");

        return new ApiResponse<UserWithPermissions>(result);
    }
}