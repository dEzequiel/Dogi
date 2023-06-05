using Application.DTOs.AdoptionManager;

namespace Api.GraphQL.InputObjectTypes.Adoption;

public class AdoptionPendingInformationInputType : InputObjectType<AdoptionPendingInformation>
{
    protected override void Configure(IInputObjectTypeDescriptor<AdoptionPendingInformation> descriptor)
    {
        descriptor.Field(f => f.IndividualProceedingId).Type<NonNullType<UuidType>>();
        descriptor.Field(f => f.AdoptionPendingData).Type<NonNullType<AdoptionPendingInputType>>();
    }
}