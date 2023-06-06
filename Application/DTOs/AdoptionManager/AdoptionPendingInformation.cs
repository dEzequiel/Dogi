using Domain.Entities.Adoption;

namespace Application.DTOs.AdoptionManager;

public class AdoptionPendingInformation
{
    public Guid IndividualProceedingId { get; init; }

    public AdoptionPending AdoptionPendingData { get; init; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="individualProceedingId"></param>
    /// <param name="adoptionPendingData"></param>
    public AdoptionPendingInformation(Guid individualProceedingId, AdoptionPending adoptionPendingData)
    {
        IndividualProceedingId = individualProceedingId;
        AdoptionPendingData = adoptionPendingData;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public AdoptionPendingInformation()
    {
    }
}