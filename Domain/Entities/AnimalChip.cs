using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
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

        public static Result<AnimalChip> Create(
            Guid id, 
            AnimalChip owner, 
            Address addressAddress)
        {
            if (id == Guid.Empty)
                return Result.Failure<AnimalChip>(DomainErrors.AnimalChip.AnimalChipIdIsNullOrEmpty);

            if (owner == null)
                return Result.Failure<AnimalChip>(DomainErrors.AnimalChip.AnimalChipIdIsNullOrEmpty);
        }
    }
}
