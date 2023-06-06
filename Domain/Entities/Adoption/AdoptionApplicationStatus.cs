namespace Domain.Entities.Adoption;

/// <summary>
/// Support table representing records equivalent to AdoptionApplicationStatuses domain enumerator.
/// </summary>
public class AdoptionApplicationStatus
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Status name.
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// AdoptionApplications relationship.
    /// </summary>
    public virtual ICollection<AdoptionApplication>? AdoptionApplications { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="status"></param>
    public AdoptionApplicationStatus(int id, string status)
    {
        Id = id;
        Status = status;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public AdoptionApplicationStatus()
    {
    }
}