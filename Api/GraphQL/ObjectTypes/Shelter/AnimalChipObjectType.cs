using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class AnimalChipObjectType : ObjectType<AnimalChip>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimalChip> descriptor)
        {
            descriptor.Ignore(f => f.PersonIdentifierId);
            descriptor.Ignore(f => f.ReceptionDocumentId);

            descriptor.Field(f => f.Person)
                .Authorize(Permissions.CanReadPerson.ToString());
        }
    }
}