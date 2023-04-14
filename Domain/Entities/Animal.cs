using Domain.Common;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Exceptions.Result;

namespace Domain.Entities
{
    public class Animal : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid IndividualProceedingId { get; private set; }
        public Sex Sex { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public string Color { get; private set; } = string.Empty;
        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual IndividualProceeding IndividualProceeding { get; set; } = null!;

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
            Guid individualProceedingId,
            string name,
            int age,
            string color) : base(id)
        {
            IndividualProceedingId = individualProceedingId;
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
            Guid individualProceedingId,
            string name,
            int age,
            string color)
        {
            if (id == Guid.Empty)
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalIdIsNullOrEmpty);

            if (individualProceedingId == Guid.Empty)
                return Result.Failure<Animal>(DomainErrors.Animal.IndividualProceedingIdIsNullOrEmpty);

            if (string.IsNullOrEmpty(name))
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalNameCantBeNullOrEmpty);

            if (age < 0)
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalAgeCantBeLowerThanZero);

            if (string.IsNullOrEmpty(color))
                return Result.Failure<Animal>(DomainErrors.Animal.AnimalColorCantBeNullOrEmpty);

            return new Animal(id, individualProceedingId, name, age, color);

        }

    }
}
