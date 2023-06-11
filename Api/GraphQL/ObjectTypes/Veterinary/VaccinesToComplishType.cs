using Application.DTOs.VeterinaryManager;

namespace Api.GraphQL.ObjectTypes.Veterinary;

public class VaccinesToComplishType : ObjectType<VaccinesToComplish>
{
    protected override void Configure(IObjectTypeDescriptor<VaccinesToComplish> descriptor)
    {
        descriptor.Field(f => f.Needed).Type<ListType<UuidType>>();
        descriptor.Field(f => f.NotNeeded).Type<ListType<UuidType>>();
    }
}