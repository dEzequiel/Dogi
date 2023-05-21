using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// Represents the electronic chip of an animal.
    /// </summary>
    public class AnimalChip : AuditableEntity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string ChipNumber { get; set; } = null!;
        public string? Name { get; set; }
        public string OwnerIdentifier { get; set; } = null!;
        public string OwnerContact { get; set; } = null!;
        public bool? OwnerIsResponsible { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="chipNumber"></param>
        /// <param name="ownerPersonalIdentifier"></param>
        /// <param name="ownerContact"></param>
        /// <param name="ownerIsResponsible"></param>
        private AnimalChip(Guid id,
            string name,
            string chipNumber,
            string ownerPersonalIdentifier,
            string ownerContact,
            bool ownerIsResponsible) : base(id)
        {
            Name = name;
            ChipNumber = chipNumber;
            OwnerIdentifier = ownerPersonalIdentifier;
            OwnerContact = ownerContact;
            OwnerIsResponsible = ownerIsResponsible;
        }

        public AnimalChip() : base(Guid.NewGuid()) { }

    }
}
