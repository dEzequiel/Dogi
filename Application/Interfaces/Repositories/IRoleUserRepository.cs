using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRoleUserRepository
{
    /// <summary>
    /// Get User roles by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<IEnumerable<RoleUser>?> GetAsync(Guid userId);
}