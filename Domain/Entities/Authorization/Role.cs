namespace Domain.Entities;

public class Role
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Role name.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Permission relationship.
    /// </summary>
    public virtual ICollection<Permission> Permissions { get; set; }

    /// <summary>
    /// User relationship.
    /// </summary>
    public virtual ICollection<User> Users { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public Role()
    {
    }
}