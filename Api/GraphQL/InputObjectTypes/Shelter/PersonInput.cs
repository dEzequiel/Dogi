using Domain.Entities.Shelter;

namespace Api.GraphQL.InputObjectTypes.Shelter
{
    public class PersonInput : InputObjectType<Person>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Person> descriptor)
        {
            descriptor
                .Field(f => f.PersonIdentifier)
                .Type<StringType>();

            descriptor
                .Field(f => f.Name)
                .Type<NonNullType<StringType>>();

            descriptor
                .Field(f => f.Lastname)
                .Type<StringType>();

            descriptor
                .Field(f => f.Contact)
                .Type<NonNullType<StringType>>();

            descriptor
                .Field(f => f.Address)
                .Type<AddressInput>();

            descriptor.Ignore(f => f.IsBan);
            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.LastModified);
        }
    }
}