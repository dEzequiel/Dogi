using Domain.Entities;

namespace Api.GraphQLTypes;

public class ReceptionDocumentType : ObjectType<ReceptionDocument>
{
    protected override void Configure(IObjectTypeDescriptor<ReceptionDocument> descriptor)
    {
        descriptor
            .Field(f => f.Id)
            .Type<NonNullType<UuidType>>();
        descriptor.Field(f => f.HasChip)
            .Type<BooleanType>();
        descriptor.Field(f => f.Observations)
            .Type<StringType>();
        descriptor.Field(f => f.PickupLocation)
            .Type<StringType>();
        descriptor.Field(f => f.PickupDate)
            .Type<DateType>();

        descriptor.Ignore((f => f.IndividualProceeding));
    }
}