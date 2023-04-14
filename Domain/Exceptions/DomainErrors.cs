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
            public static readonly Error ReceptionIdIsNullOrEmpty = new Error("ReceptionDocument.Id", "ReceptionDocument Id can't have null or default values.");
            public static readonly Error ActorIsNullOrEmpty = new Error("ReceptionDocument.Actor", "Actor can't have null or default values.");
            public static readonly Error CategoryIsNullOrEmpty = new Error("ReceptionDocument.Category", "Category can't have null or default values.");
            public static readonly Error ColorIsEmpty = new Error("ReceptionDocument.Color", "Color can't be null or empty.");
        }

        /// <summary>
        /// Collection of Errors related to Animal Entity.
        /// </summary>
        public static class Animal
        {
            public static readonly Error AnimalIdIsNullOrEmpty = new Error("Animal.Id", "Animal Id can't have null or default values");
            public static readonly Error IndividualProceedingIdIsNullOrEmpty = new Error("Animal.IndividualProceedingId", "IndividualProceedingId can't have null or default values.");
            public static readonly Error AnimalNameCantBeNullOrEmpty = new Error("Animal.Name", "Name can't have null or empty values.");
            public static readonly Error AnimalAgeCantBeLowerThanZero = new Error("Animal.Age", "Age can't have value lower tan zeros.");
            public static readonly Error AnimalColorCantBeNullOrEmpty = new Error("Animal.Color", "Color can't have null or empty values.");
        }

        /// <summary>
        /// Collection of Errors related to AnimalChip Entity.
        /// </summary>
        public static class AnimalChip
        {
            public static readonly Error AnimalChipIdIsNullOrEmpty = new Error("AnimalChip.Id", "AnimalChip Id can't have null or default values.");
            public static readonly Error AnimalChipOwnerIsNull = new Error("AnimalChip.Owner", "AnimalChip Owner can't have null values.");

        }

        /// <summary>
        /// Collection of Errors related to IndividualProceeding Entity.
        /// </summary>
        public static class IndividualProceeding
        {
            public static readonly Error IndividualProcessIdIsNullOrEmpty = new Error("IndividualProcess.Id", "IndividualProcess Id can't have null or default values.");
            public static readonly Error IndividualProcessReceptionDocumentIdIsNullOrEmpty = new Error("IndividualProcess.ReceptionDocumentId", "IndividualProcess ReceptionDocumentId can't have null or default values.");
            public static readonly Error IndividualProcessStatusIsNull= new Error("IndividualProcess.Status", "IndividualProcess Status can't have null values.");
            public static readonly Error IndividualProcessAnimalCategorysIsNull = new Error("IndividualProcess.AnimalCategory", "IndividualProcess Status can't have null values.");
        }
    }
}
