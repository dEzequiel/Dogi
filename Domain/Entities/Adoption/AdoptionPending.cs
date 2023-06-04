using Domain.Common;
using Domain.Entities.Shelter;

namespace Domain.Entities.Adoption;

public class AdoptionPending : Entity
{
    /// <summary>
    /// Individual proceeding allowed to be adopted.
    /// </summary>
    public Guid IndividualProceedingId { get; set; }

    /// <summary>
    /// Adoption status identifier.
    /// </summary>
    public int AdoptionPendingStatusId { get; set; }

    /// <summary>
    /// Adoption description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Individual proceeding relationship.
    /// </summary>
    public virtual IndividualProceeding IndividualProceeding { get; set; } = null!;

    /// <summary>
    /// Adoption pending status relationship.
    /// </summary>
    public virtual AdoptionPendingStatus AdoptionPendingStatus { get; set; } = null!;

    /// <summary>
    /// Adoption applications.
    /// </summary>
    public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="individualProceedingId"></param>
    /// <param name="description"></param>
    public AdoptionPending(Guid id, Guid individualProceedingId, string? description) : base(id)
    {
        IndividualProceedingId = individualProceedingId;
        Description = description;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    public AdoptionPending(Guid id) : base(id)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public AdoptionPending() : base(Guid.NewGuid())
    {
    }
}