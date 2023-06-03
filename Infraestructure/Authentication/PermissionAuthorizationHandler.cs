using Application.Service.Abstraction.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Authentication;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private const string ID_KEY = "Id";
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
        var userId = context.User.Claims.FirstOrDefault(x => x.Type == ID_KEY)?.Value;
        if (!Guid.TryParse(userId, out Guid parsedUserId))
        {
            return;
        }

        using IServiceScope scope = ServiceScopeFactory.CreateScope();

        IRoleUserReadService roleUserReadService = scope.ServiceProvider.GetRequiredService<IRoleUserReadService>();

        HashSet<string> permissions = await roleUserReadService.GetPermissionsAsync(parsedUserId);

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}