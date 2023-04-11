using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Domain.ValueObjects;

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
        public AnimalChipOwner Owner { get; set; }
        public Address Address { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="addressAddress"></param>
        private AnimalChip(Guid id, AnimalChipOwner owner, Address address) : base(id)
        {
            Owner = owner;
            Address = address;
        }

        /// <summary>
        /// Static Factory Pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static Result<AnimalChip> Create(
            Guid id, 
            AnimalChipOwner owner, 
            Address address)
        {
            if (id == Guid.Empty)
                return Result.Failure<AnimalChip>(DomainErrors.AnimalChip.AnimalChipIdIsNullOrEmpty);

            if (owner == null)
                return Result.Failure<AnimalChip>(DomainErrors.AnimalChip.AnimalChipOwnerIsNull);

            return new AnimalChip(id, owner, address);
        }
    }
}
