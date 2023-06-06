using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter;

public class SexObjectType : ObjectType<Sex>
{
    protected override void Configure(IObjectTypeDescriptor<Sex> descriptor)
    {
        descriptor.Field(f => f.IndividualProceedings)
            .Authorize(Permissions.CanReadIndividualProceeding.ToString());
    }
}