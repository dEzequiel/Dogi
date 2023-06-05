using Domain.Entities.Shelter;

namespace Api.GraphQL.ObjectTypes.Shelter;

/// <summary>
/// ReceptionDocument HotChocolate Type implementation.
/// </summary>
public class ReceptionDocumentObjectType : ObjectType<ReceptionDocument>
{
    protected override void Configure(IObjectTypeDescriptor<ReceptionDocument> descriptor)
    {
        descriptor.Ignore(f => f.IndividualProceeding);
        descriptor.Ignore(f => f.AnimalChip);
        descriptor.Ignore(f => f.IsDeleted);
    }
}