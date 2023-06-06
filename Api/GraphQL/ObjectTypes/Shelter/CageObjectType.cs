using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class CageType : ObjectType<Cage>
    {
        protected override void Configure(IObjectTypeDescriptor<Cage> descriptor)
        {
            descriptor.Authorize(Permissions.CanReadCage.ToString());
        }
    }
}