using Domain.Common;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Represents the owner found by the chip.
    /// </summary>
    public class AnimalChipOwner : ValueObject
    {

        /// <summary>
        /// Attributes.
        /// </summary>
        public string Name { get; set;  }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public bool IsResponsible { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public AnimalChipOwner() { }
        private AnimalChipOwner(string name, string lastname, string address, bool isResponsible)
        {
            Name = name;
            Lastname = lastname;
            IsResponsible = isResponsible;
            Address = address;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Lastname;
        }
    }
}
