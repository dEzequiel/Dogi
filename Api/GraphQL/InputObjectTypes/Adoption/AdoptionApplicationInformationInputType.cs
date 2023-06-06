using Application.DTOs.AdoptionManager;

namespace Api.GraphQL.InputObjectTypes.Adoption;

public class AdoptionApplicationInformationInputType : InputObjectType<AdoptionApplicationInformation>
{
    protected override void Configure(IInputObjectTypeDescriptor<AdoptionApplicationInformation> descriptor)
    {
        descriptor.Field(f => f.AdoptionPendingId).Type<NonNullType<UuidType>>();
        descriptor.Field(f => f.AdoptionApplication).Type<NonNullType<AdoptionApplicationInputType>>();
    }
}