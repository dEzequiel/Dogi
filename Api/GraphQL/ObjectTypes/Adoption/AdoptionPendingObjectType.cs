using Domain.Entities.Adoption;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Adoption;

public class AdoptionPendingObjectType : ObjectType<AdoptionPending>
{
    protected override void Configure(IObjectTypeDescriptor<AdoptionPending> descriptor)
    {
        descriptor.Field(f => f.AdoptionApplications)
            .Authorize(Permissions.CanReadAdoptionApplications.ToString());

        descriptor.Ignore(f => f.IndividualProceedingId);
        descriptor.Ignore(f => f.AdoptionPendingStatusId);
    }
}