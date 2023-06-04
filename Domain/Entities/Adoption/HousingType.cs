namespace Domain.Entities.Adoption;

public class HousingType
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Type of house.
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// AdoptionApplication relationship.
    /// </summary>
    public virtual ICollection<AdoptionApplication>? AdoptionApplications { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    public HousingType(int id, string type)
    {
        Id = id;
        Type = type;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public HousingType()
    {
    }
}