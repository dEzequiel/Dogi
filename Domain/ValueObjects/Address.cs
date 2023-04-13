using Domain.Common;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Represents an address.
    /// </summary>
    public class Address : ValueObject
    {
        /// <summary>
        /// Attributes
        /// </summary>
        public string Street { get; }
        public string City { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="street"></param>
        /// <param name="city"></param>
        private Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        /// <summary>
        /// Static Factory Pattern
        /// </summary>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <returns>Address Object</returns>
        public Address? Create(string street, string city)
        {
            if(string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city))
            {
                return null;
            }

            return new Address(street, city);
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
        }
    }
}
