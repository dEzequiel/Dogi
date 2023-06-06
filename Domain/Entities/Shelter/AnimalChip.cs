using Domain.Common;

namespace Domain.Entities.Shelter
{
    /// <summary>
    /// Represents information of electronic animal chip.
    /// </summary>
    public class AnimalChip : Entity
    {
        /// <summary>
        /// Animal chip number.
        /// </summary>
        public string ChipNumber { get; set; } = null!;

        /// <summary>
        /// Appearing name on chip.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Owner person identifier.
        /// </summary>
        public string PersonIdentifierId { get; set; } = null!;

        /// <summary>
        /// ReceptionDocument identifier.
        /// </summary>
        public Guid ReceptionDocumentId { get; set; }

        /// <summary>
        /// Status if the owner is responsible for the animal.
        /// </summary>
        public bool? OwnerIsResponsible { get; set; }

        /// <summary>
        /// Chip Person owner relationship.
        /// </summary>
        public virtual Person Person { get; set; } = null!;

        /// <summary>
        /// Reception document relationship.
        /// </summary>
        public virtual ReceptionDocument ReceptionDocument { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="chipNumber"></param>
        /// <param name="personIdentifierId"></param>
        /// <param name="ownerIsResponsible"></param>
        public AnimalChip(Guid id,
            string name,
            string chipNumber,
            string personIdentifierId,
            bool ownerIsResponsible) : base(id)
        {
            Name = name;
            ChipNumber = chipNumber;
            PersonIdentifierId = personIdentifierId;
            OwnerIsResponsible = ownerIsResponsible;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AnimalChip() : base(Guid.NewGuid())
        {
        }
    }
}