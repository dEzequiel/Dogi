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
        public virtual AnimalCategory AnimalCategory { get; set; } = null!;

        /// <summary>
        /// VaccinationCards collection relationship.
        /// </summary>
        public virtual ICollection<VaccinationCard>? VaccinationCards { get; set; }
        /// <summary>
        /// MedicalRecords collection relationship.
        /// </summary>
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
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
        public Vaccine(Guid id) : base(id) { }
        /// <summary>
        /// Constructor.
        /// </summary>
        public Vaccine() : base(Guid.NewGuid()) { }
    }
}
