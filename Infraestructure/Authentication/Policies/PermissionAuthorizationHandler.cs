using Application.Service.Abstraction.Read;
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
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var userId = context.User
            .Claims
            .FirstOrDefault(x => x.Type == "Id")?.Value;

        if (!Guid.TryParse(userId, out Guid parsedUserId))
        {
            return;
        }

        using IServiceScope scope = ServiceScopeFactory.CreateScope();

        IRoleUserReadService roleUserReadService = scope.ServiceProvider.GetService<IRoleUserReadService>();

        HashSet<string> permissions = await roleUserReadService.GetPermissionsAsync(parsedUserId);

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}