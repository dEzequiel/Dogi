using Domain.Common;

namespace Domain.Entities
{
    public sealed class Person : Entity
    {
        /// <summary>
        /// Attributes
        /// </summary>
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        public Person(Guid id, string name, string firstName, string? lastName) : base(id)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
