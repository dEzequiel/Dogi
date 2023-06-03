using Application.Service.Abstraction.Read;
using Domain.Entities.Authorization;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Authentication;

/// <summary>
/// Handler authorization to check if current context user has request permissions.
/// </summary>
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement, IResolverContext>
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
        PermissionRequirement requirement,
        IResolverContext resource)
    {
        var httpCtx = resource.ContextData[HTTP_CONTEXT] as HttpContext;
        var user = (User)httpCtx.Items["User"];

        if (!Guid.TryParse(user.Id.ToString(), out Guid parsedUserId))
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