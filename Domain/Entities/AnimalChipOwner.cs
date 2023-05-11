using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Represents the owner found by the chip.
    /// </summary>
    public class AnimalChipOwner : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; }
        public bool IsResponsible { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual AnimalChip AnimalChip { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public AnimalChipOwner() : base(Guid.NewGuid()) { }
        private AnimalChipOwner(Guid id, string name, string lastname, Address address, bool isResponsible) : base(id)
        {
            Name = name;
            Lastname = lastname;
            IsResponsible = isResponsible;
            Address = address;
        }
    }
}
