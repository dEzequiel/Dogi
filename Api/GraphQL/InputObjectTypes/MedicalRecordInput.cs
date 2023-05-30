using Domain.Entities;
using Domain.Enums;

namespace Api.GraphQL.InputObjectTypes
{
    public class MedicalRecordInput : InputObjectType<MedicalRecord>
    {
        protected override void Configure(IInputObjectTypeDescriptor<MedicalRecord> descriptor)
        {
            descriptor.Field(f => f.IndividualProceedingId).Type<NonNullType<UuidType>>();

            descriptor.Field(f => f.MedicalStatusId)
                .Type<NonNullType<IntType>>()
                .DefaultValue(((int)MedicalRecordStatuses.Waiting));

            descriptor.Field(f => f.Observations).Type<StringType>();
            descriptor.Field(f => f.Conclusions).Type<StringType>();

            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.IndividualProceeding);
            descriptor.Ignore(f => f.MedicalRecordStatus);
        }
    }
}
