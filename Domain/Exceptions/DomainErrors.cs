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

        /// <summary>
        /// Collection of Errors related to ReceptionDocument Entity.
        /// </summary>
        public static class ReceptionDocument
        {
            public static readonly Error ReceptionIdIsNullOrEmpty = new Error("ReceptionDocument.Id", "ReceptionDocument Id can't have null or default value.");
            public static readonly Error ActorIsNullOrEmpty = new Error("ReceptionDocument.Actor", "Actor can't have null or default value.");
            public static readonly Error CategoryIsNullOrEmpty = new Error("ReceptionDocument.Category", "Category can't have null or default value.");
            public static readonly Error ColorIsEmpty = new Error("ReceptionDocument.Color", "Color can't be null or empty.");
        }

        /// <summary>
        /// Collection of Errors related to Animal Entity.
        /// </summary>
        public static class Animal
        {
            public static readonly Error AnimalIdIsNullOrEmpty = new Error("Animal.Id", "Animal Id can't have null or default value");
            public static readonly Error ReceptionDocumentIdIsNullOrEmpty = new Error("Animal.ReceptionDocumentId", "ReceptionDocumentId can't have null or default value.");
            public static readonly Error AnimalNameCantBeNullOrEmpty = new Error("Animal.Name", "Name can't have null or empty value.");
            public static readonly Error AnimalAgeCantBeLowerThanZero = new Error("Animal.Age", "Age can't have value lower tan zero.");
            public static readonly Error AnimalColorCantBeNullOrEmpty = new Error("Animal.Color", "Color can't have null or empty value.");
        }
    }
}
