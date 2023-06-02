namespace Domain.Entities;

public class RoleUser
{
    /// <summary>
    /// Role identifier.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// User identifier.
    /// </summary>
    public Guid UserId { get; set; }
}