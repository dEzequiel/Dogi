using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;

namespace Domain.Entities
{
    public sealed class Person : Entity
    {
        /// <summary>
        /// Attributes
        /// </summary>
        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string? LastName { get; private set; }
        public int? Age { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        private Person(Guid id, string name, string firstName, string? lastName, int? age) : base(id)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        /// <summary>
        /// Static Factory Pattern. Create new Person objects passing validations.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <returns>Result of creating a Person object operation.</returns>
        public static Result<Person> Create(Guid id, string name, string firstName, string? lastName, int? age)
        {
            var person = new Person(id, name, firstName, lastName, age);

            if(person.Age < 0)
            {
                return Result.Failure<Person>(DomainErrors.Person.AgeIsZeroOrLower);
            }

            return person;
        }
    }
}
