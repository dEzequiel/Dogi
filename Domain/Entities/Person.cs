using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Person Entity representing an external person from shelter.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Person Identifier.
        /// </summary>
        public string PersonIdentifier { get; set; } = null!;
        /// <summary>
        /// Person Name/
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Person Lastname.
        /// </summary>
        public string? Lastname { get; set; }
        /// <summary>
        /// Person contact.
        /// </summary>
        public string? Contact { get; set; }
        /// <summary>
        /// Person Address.
        /// </summary>
        public Address Address { get; set; } = null!;
        /// <summary>
        /// Person ban status.
        /// </summary>
        public bool IsBan { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Last modification date.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual ICollection<PersonBannedInformation>? Bans { get; set; }

        /// <summary>
        /// Animal chip relationship.
        /// </summary>
        public virtual AnimalChip? AnimalChip { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="personalIdentifier"></param>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <param name="contact"></param>
        /// <param name="address"></param>
        /// <param name="isBan"></param>
        public Person(string personalIdentifier,
            string? name,
            string? lastname,
            string? contact,
            Address? address,
            bool isBan,
            DateTime created,
            DateTime? lastModified)
        {
            PersonIdentifier = personalIdentifier;
            Name = name;
            Lastname = lastname;
            Contact = contact;
            Address = address;
            IsBan = isBan;
            Created = created;
            LastModified = lastModified;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Person() { }

    }
}