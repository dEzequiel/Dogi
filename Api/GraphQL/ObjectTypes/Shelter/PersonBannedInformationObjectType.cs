using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class PersonBannedInformationObjectType : ObjectType<PersonBannedInformation>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonBannedInformation> descriptor)
        {
            descriptor.Field(f => f.Person)
                .Authorize(Permissions.CanReadPerson.ToString());

            descriptor.Ignore(f => f.PersonIdentifierId);
        }
    }
}