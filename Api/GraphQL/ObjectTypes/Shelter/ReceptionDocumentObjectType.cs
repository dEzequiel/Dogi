using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter;

/// <summary>
/// ReceptionDocument HotChocolate Type implementation.
/// </summary>
public class ReceptionDocumentObjectType : ObjectType<ReceptionDocument>
{
    protected override void Configure(IObjectTypeDescriptor<ReceptionDocument> descriptor)
    {
        descriptor.Field(f => f.IndividualProceeding)
            .Authorize(Permissions.CanReadIndividualProceeding.ToString());

        descriptor.Field(f => f.AnimalChip)
            .Authorize(Permissions.CanReadCage.ToString());
    }
}