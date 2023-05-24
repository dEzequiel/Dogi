using Domain.Common;
using Domain.Support;

namespace Domain.Entities
{
    /// <summary>
    /// Represents a Vaccine.
    /// </summary>
    public class Vaccine : Entity
    {
        /// <summary>
        /// Vaccine name.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Vaccine animal category.
        /// </summary>
        public int AnimalCategoryId { get; set; }
        public string? Description { get; set; }

        /// <summary>
        /// Animal category relationship.
        /// </summary>
        public AnimalCategory AnimalCategory { get; set; } = null!;

        /// <summary>
        /// VaccinationCards collection relationship.
        /// </summary>
        public List<VaccinationCard> VaccinationCards { get; } = new();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="animalCategoryId"></param>
        /// <param name="description"></param>
        public Vaccine(Guid id, string name, int animalCategoryId, string? description) : base(id)
        {
            Name = name;
            AnimalCategoryId = animalCategoryId;
            Description = description;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public Vaccine(Guid id) : base(id)
        {
        }
    }
}
