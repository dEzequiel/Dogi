using Domain.Entities;

namespace Domain.Support
{
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
        /// Navigation properties.
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