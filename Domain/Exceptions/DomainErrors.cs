namespace Domain.Exceptions
{
    /// <summary>
    /// Collection of Errors related to Domain.
    /// </summary>
    public static class DomainErrors
    {
        /// <summary>
        /// Collection of Errors related to Person Entity.
        /// </summary>
        public static class Person
        {
            public static readonly Error AgeIsZeroOrLower = new Error("Person.CreatingPerson.", "Person can't have a age of zero or lower.");
        }
    }
}
