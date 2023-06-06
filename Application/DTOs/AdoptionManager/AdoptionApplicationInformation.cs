using Domain.Entities.Adoption;

namespace Application.DTOs.AdoptionManager;

public class AdoptionApplicationInformation
{
    public Guid AdoptionPendingId { get; set; }

    public AdoptionApplication AdoptionApplication { get; set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionPendingId"></param>
    /// <param name="adoptionApplication"></param>
    public AdoptionApplicationInformation(Guid adoptionPendingId, AdoptionApplication adoptionApplication)
    {
        AdoptionPendingId = adoptionPendingId;
        AdoptionApplication = adoptionApplication;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public AdoptionApplicationInformation()
    {
    }
}