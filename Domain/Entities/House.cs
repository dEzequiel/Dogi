using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class House : AuditableEntity
    {
        /// <summary>
        /// Attributes
        /// </summary>
        public Address Address { get; set; }
        public IList<Person> Persons { get; private set; } = new List<Person>();
        public Poblation PoblationLevel { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <param name="persons"></param>
        /// <param name="poblationLevel"></param>
        public House(Guid id, Address address, IList<Person> persons, Poblation poblationLevel) : base(id)
        {
            Address = address;
            Persons = persons;
            PoblationLevel = poblationLevel;
        }
    }
}
