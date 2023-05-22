using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records equivalent to AnimalCategory domain enumerator.
    /// </summary>
    public class AnimalCategory
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category type.
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Collection of Individual proceeding relationships.
        /// </summary>
        public ICollection<IndividualProceeding> IndividualProceedings { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public AnimalCategory(int id, string type)
        {
            Id = id;
            Type = type;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public AnimalCategory() { }

    }
}
