using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor
                .Field(f => f.Bans)
                .Type<ListType<PersonBannedInformationObjectType>>()
                .Authorize(Permissions.CanReadPerson.ToString());

            descriptor.Field(f => f.User)
                .Authorize(Permissions.CanReadUser.ToString());

            descriptor.Field(f => f.AnimalChip)
                .Authorize(Permissions.CanReadAnimalChip.ToString());

            descriptor.Ignore(f => f.UserId);
        }
    }
}