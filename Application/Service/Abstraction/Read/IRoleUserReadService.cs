using Crosscuting.Base.Interfaces;

namespace Application.Service.Abstraction.Read;

public interface IRoleUserReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get user permissions.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<HashSet<string>> GetPermissionsAsync(Guid userId);
}