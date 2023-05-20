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
        public int Id { get; set;  }

        /// <summary>
        /// Sex type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public ICollection<IndividualProceeding> IndividualProceedings { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Sex(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
