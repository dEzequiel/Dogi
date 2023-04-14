using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Domain.Support;

namespace Domain.Entities
{
    public class Animal : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public int SexId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public string Color { get; private set; } = string.Empty;

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual IndividualProceeding IndividualProceeding { get; private set; }
        public virtual Sex Sex { get; private set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="individualProceedingId"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="color"></param>
        public Animal(Guid id) : base(id) { }

        private Animal(
            Guid id,
            string name,
            int age,
            string color) : base(id)
        {
            Name = name;
            Age = age;
            Color = color;
        }

        /// <summary>
        /// Static Factory Pattern. Creates new Animal in valid state.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="individualProceedingId"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Result<Animal> Create(
            Guid id,
            string name,
            int age,
            string color)
        {
            if (id == Guid.Empty)
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalIdIsNullOrEmpty);

            if (string.IsNullOrEmpty(name))
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalNameCantBeNullOrEmpty);

            if (age < 0)
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalAgeCantBeLowerThanZero);

            if (string.IsNullOrEmpty(color))
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalColorCantBeNullOrEmpty);

            return new Animal(id, name, age, color);

        }

    }
}
