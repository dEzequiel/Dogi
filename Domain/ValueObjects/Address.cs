using Domain.Common;

namespace Domain.ValueObjects
{
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
        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
        }
    }
}
