using Domain.Entities.Shelter;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class PersonBannedInformationType : ObjectType<PersonBannedInformation>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonBannedInformation> descriptor)
        {
            descriptor.Field(f => f.PersonIdentifierId)
                .Type<NonNullType<StringType>>();

            descriptor.Field(f => f.Observations)
                .Type<StringType>();

            descriptor.Ignore(f => f.Person);
        }
    }
}