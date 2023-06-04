using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Authentication.Policies;

/// <summary>
/// Handler authorization to check if current context user has request permissions.
/// </summary>
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private const string HTTP_CONTEXT = "HttpContext";
    private readonly IServiceScopeFactory ServiceScopeFactory;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="serviceScopeFactory"></param>
    public PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
    {
        ServiceScopeFactory = serviceScopeFactory;
    }

    ///<inheritdoc />
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var permissions = context.User
            .Claims
            .Where(x => x.Type == "Permissions")
            .Select(x => x.Value)
            .ToHashSet();

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}