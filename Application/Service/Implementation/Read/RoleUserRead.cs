using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class RoleUserRead : IRoleUserReadService
{
    private readonly ILogger<RoleUserRead> Logger;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="userReadService"></param>
    public RoleUserRead(ILogger<RoleUserRead> logger, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
    }

    public async Task<HashSet<string>> GetPermissionsAsync(Guid userId)
    {
        Logger.LogInformation("RoleUserRead --> GetPermissionsAsync --> Start");

        var roleUserRepository = UnitOfWork.RoleUserRepository;
        var roleRepository = UnitOfWork.RoleRepository;

        var assignedRoles = await roleUserRepository.GetAsync(userId);

        var rolesIds = assignedRoles.Select(x => x.RoleId).ToList();

        var roles = await roleRepository.GetAsync(rolesIds);

        Logger.LogInformation("RoleUserRead --> GetPermissionsAsync --> End");

        return roles.SelectMany(x => x.Permissions)
            .Select(x => x.Name)
            .ToHashSet();
    }

    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}