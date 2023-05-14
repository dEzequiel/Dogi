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
        public Person Owner { get; set; }
        public string? Name { get; set; }
        public string ChipNumber { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="addressAddress"></param>
        public AnimalChip() : base(Guid.NewGuid()) { }
        private AnimalChip(Guid id, string name, string chipNumber, Person animalChipOwner) : base(id)
        {
            Name = name;
            ChipNumber = chipNumber;
            Owner = animalChipOwner;
        }
    }
}
