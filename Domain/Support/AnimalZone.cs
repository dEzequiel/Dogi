using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records equivalent to AnimalZone domain enumerator.
    /// </summary>
    public class AnimalZone
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        ///<summary>
        /// Zone name.
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// Collection of Cages relationships.
        ///</summary>
        public virtual ICollection<Cage>? Cages { get; set; }

        ///<summary>
        /// Constructor.
        ///</summary>
        ///<param name="id"></param>
        ///<param name="name"></param>
        public AnimalZone(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}