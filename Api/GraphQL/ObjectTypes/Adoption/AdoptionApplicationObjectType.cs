using Domain.Entities.Adoption;

namespace Api.GraphQL.ObjectTypes.Adoption;

public class AdoptionApplicationObjectType : ObjectType<AdoptionApplication>
{
    protected override void Configure(IObjectTypeDescriptor<AdoptionApplication> descriptor)
    {
        descriptor.Ignore(f => f.UserId);
        descriptor.Ignore(f => f.AdoptionPendingId);
        descriptor.Ignore(f => f.HousingTypeId);
        descriptor.Ignore(f => f.AdoptionApplicationStatusId);
    }
}