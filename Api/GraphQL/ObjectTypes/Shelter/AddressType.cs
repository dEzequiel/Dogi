using Domain.ValueObjects;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class AddressType : ObjectType<Address>
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            descriptor
                .Field(f => f.Street)
                .Type<StringType>();

            descriptor
                .Field(f => f.City)
                .Type<StringType>();

            descriptor
                .Field(f => f.ZipCode)
                .Type<StringType>();
        }
    }
}