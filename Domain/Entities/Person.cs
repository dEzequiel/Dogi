using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person
    {

        /// <summary>
        /// Attributes.
        /// </summary>
        public string PersonIdentifier { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Contact { get; set; }
        public Address? Address { get; set; }
        public bool IsBan { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual ICollection<AnimalChip> AnimalChips { get; set; }

        public virtual ICollection<PersonBannedInformation> PersonBannedInformations { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="personIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <param name="contact"></param>
        /// <param name="address"></param>
        public Person(string personalIdentifier,
            string? name,
            string? lastname,
            string? contact,
            Address? address,
            bool isBan) 
        {
            PersonIdentifier = personalIdentifier;
            Name = name;
            Lastname = lastname;
            Contact = contact;
            Address = address;
            IsBan = isBan;
        }
    }
}