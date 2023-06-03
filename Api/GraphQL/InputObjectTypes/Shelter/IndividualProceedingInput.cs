using Domain.Entities.Shelter;

namespace Api.GraphQL.InputObjectTypes.Shelter
{
    /// <summary>
    /// IndividualProceeding input object type.
    /// </summary>
    public class IndividualProceedingInput : InputObjectType<IndividualProceeding>
    {
        protected override void Configure(IInputObjectTypeDescriptor<IndividualProceeding> descriptor)
        {
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.Age).Type<IntType>();
            descriptor.Field(f => f.Color).Type<StringType>();
            descriptor.Field(f => f.CategoryId).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.SexId).Type<NonNullType<IntType>>();

            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.ReceptionDocumentId);
            descriptor.Ignore(f => f.CageId);
            descriptor.Ignore(f => f.IndividualProceedingStatusId);
            descriptor.Ignore(f => f.VaccinationCardId);
            descriptor.Ignore(f => f.IsDeleted);

            descriptor.Ignore(f => f.ReceptionDocument);
            descriptor.Ignore(f => f.IndividualProceedingStatus);
            descriptor.Ignore(f => f.AnimalCategory);
            descriptor.Ignore(f => f.Sex);
            descriptor.Ignore(f => f.Cage);
            descriptor.Ignore(f => f.MedicalRecords);
            descriptor.Ignore(f => f.VaccinationCard);

            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.CreatedBy);
            descriptor.Ignore(f => f.LastModified);
            descriptor.Ignore(f => f.LastModifiedBy);
        }
    }
}