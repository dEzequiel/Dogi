using Domain.Common;
using Domain.Entities.Authorization;
using Domain.ValueObjects;

namespace Domain.Entities.Adoption;

public class AdoptionApplication : AuditableEntity
{
    /// <summary>
    /// Adoption pending identifier.
    /// </summary>
    public Guid AdoptionPendingId { get; set; }

    /// <summary>
    /// User identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// House type identifier,
    /// </summary>
    public int HousingTypeId { get; set; }

    /// <summary>
    /// House description.
    /// </summary>
    public virtual House HouseDescription { get; set; } = null!;

    /// <summary>
    /// Other animals.
    /// </summary>
    public virtual OtherAnimal? OtherAnimals { get; set; }

    /// <summary>
    /// Personal references.
    /// </summary>
    public virtual PersonalReference? PersonalReferences { get; set; }

    /// <summary>
    /// AdoptionPending relationship.
    /// </summary>
    public virtual AdoptionPending AdoptionPending { get; set; } = null!;

    /// <summary>
    /// User relationship.
    /// </summary>
    public virtual User User { get; set; } = null!;

    /// <summary>
    /// Housing type relationship.
    /// </summary>
    public virtual HousingType HousingType { get; set; } = null!;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="adoptionPendingId"></param>
    /// <param name="userId"></param>
    /// <param name="housingTypeId"></param>
    /// <param name="houseDescription"></param>
    /// <param name="otherAnimals"></param>
    /// <param name="personalReferences"></param>
    public AdoptionApplication(Guid id, Guid adoptionPendingId, Guid userId, int housingTypeId,
        House houseDescription, OtherAnimal? otherAnimals, PersonalReference? personalReferences) : base(id)
    {
        AdoptionPendingId = adoptionPendingId;
        UserId = userId;
        HousingTypeId = housingTypeId;
        HouseDescription = houseDescription;
        OtherAnimals = otherAnimals;
        PersonalReferences = personalReferences;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    public AdoptionApplication(Guid id) : base(id)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    public AdoptionApplication() : base(Guid.NewGuid())
    {
    }
}