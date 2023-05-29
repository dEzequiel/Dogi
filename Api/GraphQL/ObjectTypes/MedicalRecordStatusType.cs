using Domain.Support;

namespace Api.GraphQL.ObjectTypes
{
    public class MedicalRecordStatusType : ObjectType<MedicalRecordStatus>
    {
        protected override void Configure(IObjectTypeDescriptor<MedicalRecordStatus> descriptor)
        {
            descriptor.Field(f => f.MedicalRecords).Type<ListType<MedicalRecordType>>();

        }
    }
}
