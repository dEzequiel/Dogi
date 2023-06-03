using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Infraestructure.Helpers;

/// <summary>
/// Authorization attribute to apply policies.
/// </summary>
public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission)
        : base(policy: permission.ToString())
    {
    }
}