using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRoleRepository
{
    /// <summary>
    /// Get role by id.
    /// </summary>
    /// <param name="rolesIds"></param>
    /// <returns></returns>
    Task<IEnumerable<Role>> GetAsync(IEnumerable<int> rolesIds);
}