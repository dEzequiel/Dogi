﻿using Microsoft.AspNetCore.Authorization;

namespace Infraestructure.Authentication.Policies;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="permission"></param>
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}