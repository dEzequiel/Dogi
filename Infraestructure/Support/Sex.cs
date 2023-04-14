using Domain.Common;

namespace Domain.SupportTables
{
    /// <summary>
    /// Support table representing records equivalent to Sex domain enumerator.
    /// </summary>
    public class Sex : SupportTable
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Sex(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
