using Domain.Entities;

namespace Api.GraphQL.GraphQLTypes;

/// <summary>
/// ReceptionDocument HotChocolate Type implementation.
/// </summary>
public class ReceptionDocumentType : ObjectType<ReceptionDocument>
{
    protected override void Configure(IObjectTypeDescriptor<ReceptionDocument> descriptor)
    {
        descriptor
            .Field(f => f.Id)
            .Type<NonNullType<UuidType>>();

        descriptor.Field(f => f.IsDeleted)
            .Type<NonNullType<BooleanType>>();

        descriptor.Field(f => f.HasChip)
            .Type<BooleanType>();

        descriptor.Field(f => f.Observations)
            .Type<StringType>();

        descriptor.Field(f => f.PickupLocation)
            .Type<NonNullType<StringType>>();

        descriptor.Field(f => f.PickupDate)
            .Type<NonNullType<DateType>>();

        descriptor.Ignore(f => f.IndividualProceeding);
    }
}