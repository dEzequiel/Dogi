using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Domain.Support;

namespace Domain.Entities
{
    public class Animal : AuditableEntity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public int SexId { get;  set; }
        public int AnimalCategoryId { get; set; }
        public string Name { get;  set; } = string.Empty;
        public int Age { get;  set; }
        public string Color { get;  set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual IndividualProceeding IndividualProceeding { get; private set; }
        public virtual Sex Sex { get; private set; } = null!;
        public virtual AnimalCategory AnimalCategory { get; set; } = null;

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
            int sexId,
            int animalCategoryId,
            string name,
            int age,
            string color) : base(id)
        {
            SexId = sexId;
            AnimalCategoryId = animalCategoryId;
            Name = name;
            Age = age;
            Color = color;
        }

    }
}
