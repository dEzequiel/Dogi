using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    public class ReceptionDocumentInputType : InputObjectType<ReceptionDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReceptionDocument> descriptor)
        {
            descriptor.Field(f => f.Id)
              .Type<UuidType>()
              .DefaultValue(Guid.NewGuid())
              .Ignore(true);

            descriptor.Field(f => f.IsDeleted)
                .Type<NonNullType<BooleanType>>()
                .DefaultValue(false)
                .Ignore(true);

            descriptor.Field(f => f.HasChip)
                .Type<BooleanType>();

            descriptor.Field(f => f.Observations)
                .Type<StringType>();

            descriptor.Field(f => f.PickupLocation)
                .Type<NonNullType<StringType>>();

            //descriptor.Field(f => f.PickupDate)
            //    .Type<NonNullType<DateType>>()
            //    .DefaultValue(DateTimeOffset.Now);

        }
    }

}
