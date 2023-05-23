using Application.DTOs.VeterinaryManager;

namespace Api.GraphQL.InputObjectTypes
{
    public class IndividualProceedingAndMedicalRecordCredentialsInput : InputObjectType<IndividualProceedingAndMedicalRecordCredentials>
    {
        protected override void Configure(IInputObjectTypeDescriptor<IndividualProceedingAndMedicalRecordCredentials> descriptor)
        {
            descriptor.Field(f => f.IndividualProceedingId)
                .Type<NonNullType<UuidType>>();

            descriptor.Field(f => f.MedicalRecordId)
                .Type<NonNullType<UuidType>>();
        }
    }
}
