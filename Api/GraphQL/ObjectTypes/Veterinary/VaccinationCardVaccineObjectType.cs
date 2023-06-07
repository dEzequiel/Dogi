using Domain.Entities;

namespace Api.GraphQL.ObjectTypes.Veterinary;

public class VaccinationCardVaccineObjectType : ObjectType<VaccinationCardVaccine>
{
    protected override void Configure(IObjectTypeDescriptor<VaccinationCardVaccine> descriptor)
    {
        descriptor.Ignore(f => f.VaccineId);
        descriptor.Ignore(f => f.VaccinationCardId);
        descriptor.Ignore(f => f.VaccineStatusId);
    }
}