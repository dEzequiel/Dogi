using Domain.Entities.Adoption;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Adoption;

public class AdoptionApplicationObjectType : ObjectType<AdoptionApplication>
{
    protected override void Configure(IObjectTypeDescriptor<AdoptionApplication> descriptor)
    {
        descriptor.Field(f => f.User)
            .Authorize(Permissions.CanReadUser.ToString());

        descriptor.Ignore(f => f.UserId);
        descriptor.Ignore(f => f.AdoptionPendingId);
        descriptor.Ignore(f => f.HousingTypeId);
        descriptor.Ignore(f => f.AdoptionApplicationStatusId);
    }
}