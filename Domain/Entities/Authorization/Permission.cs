namespace Domain.Entities.Authorization;

public class Permission
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Permission name.
    /// </summary>
    public string Name { get; init; } = string.Empty;
}