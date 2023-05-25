using Application.DTOs.VeterinaryManager;

namespace Api.GraphQL.InputObjectTypes.VeterinaryObjects
{
    public class VaccinationCardWithVaccineCredentialsInput : InputObjectType<VaccinationCardWithVaccineCredentials>
    {
        protected override void Configure(IInputObjectTypeDescriptor<VaccinationCardWithVaccineCredentials> descriptor)
        {
            descriptor
                .Field(f => f.VaccinationCardId)
                .Type<NonNullType<UuidType>>();

            descriptor
                .Field(f => f.VaccineId)
                .Type<NonNullType<UuidType>>();
        }
    }
}
