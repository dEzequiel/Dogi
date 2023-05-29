using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.
                Field(f => f.PersonIdentifier)
                .Type<NonNullType<StringType>>();

            descriptor.
                Field(f => f.Name)
                .Type<StringType>();

            descriptor.
                Field(f => f.Lastname)
                .Type<StringType>();

            descriptor.
                Field(f => f.Contact)
                .Type<StringType>();

            descriptor.
                Field(f => f.Address)
                .Type<AddressType>();

            descriptor
                .Field(f => f.Bans)
                .Type<ListType<PersonBannedInformationType>>();

        }
    }
}