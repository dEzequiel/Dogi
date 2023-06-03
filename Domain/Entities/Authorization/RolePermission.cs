namespace Domain.Entities.Authorization;

public class RolePermission
{
    /// <summary>
    /// Role identifier.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Permission identifier.
    /// </summary>
    public int PermissionId { get; set; }
}