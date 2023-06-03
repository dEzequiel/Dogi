using Domain.Entities;

namespace Api.GraphQL.ObjectTypes.Veterinary
{
    public class MedicalRecordType : ObjectType<MedicalRecord>
    {
        protected override void Configure(IObjectTypeDescriptor<MedicalRecord> descriptor)
        {
            descriptor.Field(f => f.MedicalRecordStatus).Type<NonNullType<MedicalRecordStatusType>>();

            descriptor.Ignore(f => f.IndividualProceedingId);
            descriptor.Ignore(f => f.MedicalStatusId);
        }
    }
}