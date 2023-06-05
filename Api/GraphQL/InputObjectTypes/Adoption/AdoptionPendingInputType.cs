using Domain.Entities.Adoption;

namespace Api.GraphQL.InputObjectTypes.Adoption;

public class AdoptionPendingInputType : InputObjectType<AdoptionPending>
{
    protected override void Configure(IInputObjectTypeDescriptor<AdoptionPending> descriptor)
    {
        descriptor.Ignore(f => f.Id);
        descriptor.Ignore(f => f.AdoptionApplications);
        descriptor.Ignore(f => f.IndividualProceeding);
        descriptor.Ignore(f => f.IndividualProceedingId);
        descriptor.Ignore(f => f.AdoptionPendingStatus);
        descriptor.Ignore(f => f.AdoptionPendingStatusId);

        descriptor.Ignore(f => f.Created);
        descriptor.Ignore(f => f.CreatedBy);
        descriptor.Ignore(f => f.LastModified);
        descriptor.Ignore(f => f.LastModifiedBy);
    }
}