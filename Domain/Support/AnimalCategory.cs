using Domain.Common;
using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records equivalent to AnimalCategory domain enumerator.
    /// </summary>
    public class AnimalCategory : SupportTable
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public ICollection<IndividualProceeding> IndividualProceedings { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public AnimalCategory(int id, string type) : base(id)
        {
            Type = type;
        }
    }
}
