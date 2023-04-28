using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    public class ReceptionDocumentInputType : InputObjectType<ReceptionDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReceptionDocument> descriptor)
        {
            descriptor.Field(f => f.Id)
              .Type<UuidType>()
              .DefaultValue(Guid.NewGuid());

            descriptor.Field(f => f.HasChip)
                .Type<BooleanType>();

            descriptor.Field(f => f.Observations)
                .Type<StringType>();

            descriptor.Field(f => f.PickupLocation)
                .Type<StringType>();

            descriptor.Field(f => f.PickupDate)
                .Type<DateTimeType>();
        }
    }

}
