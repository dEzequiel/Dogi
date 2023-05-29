using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records equivalent to Sex domain enumerator.
    /// </summary>
    public class Sex
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sex type.
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// Collection of Individual proceeding relationships.
        /// </summary>
        public virtual ICollection<IndividualProceeding> IndividualProceedings { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public Sex(int id, string type)
        {
            Id = id;
            Type = type;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public Sex() { }
    }
}
