using Domain.Entities.Adoption;
using Domain.Entities.Shelter;

namespace Application.DTOs.AdoptionManager;

public class CompletedAdoptionInformation
{
    public AdoptionApplication AdoptionApplication { get; set; }
    public AdoptionPending AdoptionPending { get; set; }
    public IndividualProceeding IndividualProceeding { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionApplication"></param>
    /// <param name="adoptionPending"></param>
    /// <param name="individualProceeding"></param>
    public CompletedAdoptionInformation(AdoptionApplication adoptionApplication, AdoptionPending adoptionPending,
        IndividualProceeding individualProceeding)
    {
        AdoptionApplication = adoptionApplication;
        AdoptionPending = adoptionPending;
        IndividualProceeding = individualProceeding;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public CompletedAdoptionInformation()
    {
    }
}