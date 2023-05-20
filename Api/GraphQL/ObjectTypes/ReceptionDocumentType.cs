using Domain.Entities;

namespace Api.GraphQL.GraphQLTypes;

/// <summary>
/// ReceptionDocument HotChocolate Type implementation.
/// </summary>
public class ReceptionDocumentType : ObjectType<ReceptionDocument>
{
    protected override void Configure(IObjectTypeDescriptor<ReceptionDocument> descriptor)
    {
        descriptor.Field(f => f.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(f => f.HasChip).Type<NonNullType<BooleanType>>();
        descriptor.Field(f => f.Observations).Type<StringType>();
        descriptor.Field(f => f.PickupLocation).Type<StringType>();

        descriptor.Ignore(f => f.IndividualProceeding);
        descriptor.Ignore(f => f.IsDeleted);

    }
}