namespace Domain.Entities.Adoption;

/// <summary>
/// Support table representing records equivalent to AdoptionApplicationStatuses domain enumerator.
/// </summary>
public class AdoptionPendingStatus
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
    /// Collection of AdoptionPending relationships.
    /// </summary>
    public virtual ICollection<AdoptionPending>? AdoptionPendings { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="status"></param>
    public AdoptionPendingStatus(int id, string status)
    {
        Id = id;
        Status = status;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public AdoptionPendingStatus()
    {
    }
}