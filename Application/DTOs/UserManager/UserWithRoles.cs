namespace Application.DTOs.UserManager;

public class UserWithRoles
{
    public Guid UserId { get; set; }
    public IEnumerable<int> RolesIds { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="rolesIds"></param>
    public UserWithRoles(Guid userId, IEnumerable<int> rolesIds)
    {
        UserId = userId;
        RolesIds = rolesIds;
    }

    public UserWithRoles()
    {
    }
}