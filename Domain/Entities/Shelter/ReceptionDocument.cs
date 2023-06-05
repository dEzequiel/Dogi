using Domain.Common;

namespace Domain.Entities.Shelter
{
    /// <summary>
    /// Represents the first arrival of an animal at the shelter.
    /// </summary>
    public class ReceptionDocument : AuditableEntity
    {
        /// <summary>
        /// Chip possession.
        /// </summary>
        public bool HasChip { get; set; }

        /// <summary>
        /// First observations.
        /// </summary>
        public string? Observations { get; set; } = string.Empty;

        /// <summary>
        /// Pickup location.
        /// </summary>
        public string? PickupLocation { get; set; } = null!;

        //public DateTime PickupDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Individual proceeding relationship.
        /// </summary>
        public virtual IndividualProceeding? IndividualProceeding { get; set; }

        /// <summary>
        /// Animal chip relationship.
        /// </summary>
        public virtual AnimalChip? AnimalChip { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hasChip"></param>
        /// <param name="observations"></param>
        /// <param name="pickupLocation"></param>
        public ReceptionDocument(Guid id, bool hasChip, string? observations, string pickupLocation) : base(id)
        {
            HasChip = hasChip;
            Observations = observations;
            PickupLocation = pickupLocation;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public ReceptionDocument(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ReceptionDocument() : base(Guid.NewGuid())
        {
        }
    }
}