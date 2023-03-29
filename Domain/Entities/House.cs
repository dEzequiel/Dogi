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
        private readonly List<Person> _persons = new();
        public Address Address { get; private set; }
        public IReadOnlyCollection<Person> Persons => _persons;
        public Poblation PoblationLevel { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <param name="persons"></param>
        /// <param name="poblationLevel"></param>
        public House(Guid id, Address address, Poblation poblationLevel) : base(id)
        {
            Address = address;
            PoblationLevel = poblationLevel;
        }

        /// <summary>
        /// Add Person to House.
        /// </summary>
        /// <param name="person">Person object.</param>
        /// <returns>Added Person.</returns>
        public Person AddPerson(Person person)
        {
            _persons.Add(person);
            return person;
        }
    }
}
