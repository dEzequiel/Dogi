using Domain.Common;
using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records equivalent to Sex domain enumerator.
    /// </summary>
    public class Sex : SupportTable
    {
        /// <summary>
        /// Attributes.
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
        public Sex(int id, string type) : base(id)
        {
            Type = type;
        }
    }
}
