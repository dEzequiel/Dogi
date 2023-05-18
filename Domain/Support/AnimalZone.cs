using Domain.Common;
using Domain.Entities;

namespace Domain.Support
{
    public class AnimalZone : SupportTable
    {
        ///<summary>
        /// Attributes.
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// Navigation properties.
        ///</summary>
        public virtual ICollection<Cage>? Cages { get; set; }

        ///<summary>
        /// Constructor.
        ///</summary>
        ///<param name="id"></param>
        ///<param name="name"></param>
        public AnimalZone(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}