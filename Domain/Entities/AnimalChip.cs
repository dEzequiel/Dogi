using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;

namespace Domain.Entities
{
    /// <summary>
    /// Represents the electronic chip of an animal.
    /// </summary>
    public class AnimalChip : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid? AnimalChipOwnerId { get; set; }
        public string ChipNumber { get; set; }

        /// <summary>
        /// Navigation properties
        /// </summary>
        public virtual IndividualProceeding IndividualProceeding { get; set; }
        public virtual AnimalChipOwner? AnimalChipOwner { get;  set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="addressAddress"></param>
        public AnimalChip() : base(Guid.NewGuid()) { }
        private AnimalChip(Guid id, Guid animalChipOwnerId, string chipNumber) : base(id)
        {
            ChipNumber = chipNumber;
            AnimalChipOwnerId = animalChipOwnerId;
        }
    }
}
