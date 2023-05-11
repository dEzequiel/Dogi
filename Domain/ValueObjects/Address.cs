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
        public string ZipCode { get; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="street"></param>
        /// <param name="city"></param>
        public Address() { }
        private Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }


        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
        }
    }
}
