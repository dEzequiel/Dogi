using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    public class MedicalRecordType : ObjectType<MedicalRecord>
    {
        protected override void Configure(IObjectTypeDescriptor<MedicalRecord> descriptor)
        {
            descriptor.Ignore(f => f.IndividualProceedingId);
            descriptor.Ignore(f => f.MedicalStatusId);

        }
    }
}
