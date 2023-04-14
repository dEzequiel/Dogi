using Domain.Common;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Represents the owner found by the chip.
    /// </summary>
    public class AnimalChipOwner : ValueObject
    {

        /// <summary>
        /// Attributes.
        /// </summary>
        public string Name { get; }
        public string Lastname { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public AnimalChipOwner() { }
        private AnimalChipOwner(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

        /// <summary>
        /// Static Factory Pattern.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public AnimalChipOwner? Create(string name, string lastname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname))
            {
                return null;
            }

            return new AnimalChipOwner(name, lastname);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Lastname;
        }
    }
}
