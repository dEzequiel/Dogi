using Domain.Entities.Shelter;

namespace Api.GraphQL.InputObjectTypes.Shelter
{
    /// <summary>
    /// ReceptionDocument input type for graphql mutations.
    /// </summary>
    public class ReceptionDocumentInput : InputObjectType<ReceptionDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReceptionDocument> descriptor)
        {
            descriptor.Field(f => f.HasChip).Type<NonNullType<BooleanType>>();
            descriptor.Field(f => f.Observations).Type<StringType>();
            descriptor.Field(f => f.PickupLocation).Type<StringType>();

            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.IsDeleted);
            descriptor.Ignore(f => f.IndividualProceeding);
            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.CreatedBy);
            descriptor.Ignore(f => f.LastModified);
            descriptor.Ignore(f => f.LastModifiedBy);
        }
    }
}