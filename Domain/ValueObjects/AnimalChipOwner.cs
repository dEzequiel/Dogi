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
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Contact { get; set; }
        public Address? Address { get; set; }
        public bool IsResponsible { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public AnimalChipOwner() { }
        private AnimalChipOwner(string name, string lastname, string contact, Address address, bool isResponsible)
        {
            Name = name;
            Lastname = lastname;
            Address = address;
            Contact = contact;
            IsResponsible = isResponsible;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Lastname;
            yield return Address;
            yield return Contact;
            yield return IsResponsible;
        }
    }
}