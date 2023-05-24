using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    ///<summary>
    /// IndividualProceeding HotChocolate Type implementation.
    ///</summary>
    public class IndividualProceedingType : ObjectType<IndividualProceeding>
    {
        protected override void Configure(IObjectTypeDescriptor<IndividualProceeding> descriptor)
        {
            descriptor.Field(f => f.Id).Type<UuidType>();
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.Age).Type<IntType>();
            descriptor.Field(f => f.Color).Type<StringType>();

            descriptor.Ignore(f => f.ReceptionDocumentId);
            descriptor.Ignore(f => f.VaccinationCardId);
            descriptor.Ignore(f => f.CageId);
            descriptor.Ignore(f => f.SexId);
            descriptor.Ignore(f => f.CategoryId);
            descriptor.Ignore(f => f.IndividualProceedingStatusId);
            descriptor.Ignore(f => f.IsDeleted);
        }
    }
}