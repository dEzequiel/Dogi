using Domain.Common;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Represents an address.
    /// </summary>
    public class Address : ValueObject
    {
        /// <summary>
        /// Street name.
        /// </summary>
        public string? Street { get; }
        /// <summary>
        /// City name.
        /// </summary>
        public string? City { get; }
        /// <summary>
        /// Zip code.
        /// </summary>
        public string? ZipCode { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="zipCode"></param>
        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Address() { }


        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street ?? string.Empty;
            yield return City ?? string.Empty;
            yield return ZipCode ?? string.Empty;
        }
    }
}
