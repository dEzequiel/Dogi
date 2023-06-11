namespace Application.DTOs.UserManager;

public class UserWithPermissions
{
    public KeyValuePair<Guid, HashSet<string>?> Permissions { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="permissions"></param>
    public UserWithPermissions(KeyValuePair<Guid, HashSet<string>?> permissions)
    {
        Permissions = permissions;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserWithPermissions()
    {
    }
}