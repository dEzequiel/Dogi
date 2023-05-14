using Domain.Common;
using Domain.ValueObjects;

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
        public string OwnerPersonalIdentifier { get; set; }
        public string? Name { get; set; }
        public string ChipNumber { get; set; }
        public bool OwnerIsResponsible { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual Person AnimalChipOwner { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        /// <param name="chipNumber"></param>
        /// <param name="ownerIsResponsible"></param>


        public AnimalChip() : base(Guid.NewGuid()) { }
        private AnimalChip(Guid id, string name, string chipNumber, string ownerPersonalIdentifier, bool ownerIsResponsible) : base(id)
        {
            Name = name;
            ChipNumber = chipNumber;
            OwnerPersonalIdentifier = ownerPersonalIdentifier;
            OwnerIsResponsible = ownerIsResponsible;
        }
    }
}
