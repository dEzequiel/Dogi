using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class AnimalZoneType : ObjectType<AnimalZone>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimalZone> descriptor)
        {
            descriptor.Field(f => f.Cages)
                .Authorize(Permissions.CanReadCage.ToString());
        }
    }
}