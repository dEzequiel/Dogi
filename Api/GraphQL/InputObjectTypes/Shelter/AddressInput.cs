using Domain.ValueObjects;

namespace Api.GraphQL.InputObjectTypes.Shelter
{
    public class AddressInput : InputObjectType<Address>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Address> descriptor)
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