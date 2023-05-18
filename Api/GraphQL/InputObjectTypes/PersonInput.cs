using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    public class PersonInput : InputObjectType<Person>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Person> descriptor)
        {
            descriptor
                .Field(f => f.PersonIdentifier)
                .Type<NonNullType<StringType>>();

            descriptor
                .Field(f => f.Name)
                .Type<StringType>();

            descriptor
                .Field(f => f.Lastname)
                .Type<StringType>();

            descriptor
                .Field(f => f.Contact)
                .Type<StringType>();

            descriptor
                .Field(f => f.Address)
                .Type<AddressInput>();

            descriptor.Ignore(f => f.IsBan);

        }
    }
}