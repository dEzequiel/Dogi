using Domain.Entities;
using Domain.Enums.Veterinary;

namespace Api.GraphQL.InputObjectTypes.Veterinary
{
    public class MedicalRecordInput : InputObjectType<MedicalRecord>
    {
        protected override void Configure(IInputObjectTypeDescriptor<MedicalRecord> descriptor)
        {
            descriptor.Field(f => f.IndividualProceedingId)
                .Type<NonNullType<UuidType>>()
                .Ignore();

            descriptor.Field(f => f.MedicalStatusId)
                .Type<NonNullType<IntType>>()
                .DefaultValue(((int)MedicalRecordStatuses.Waiting))
                .Ignore();

            descriptor.Field(f => f.Observations).Type<StringType>();
            descriptor.Field(f => f.Causes).Type<StringType>();

            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.IndividualProceeding);

            descriptor.Ignore(f => f.MedicalRecordStatus);
            descriptor.Ignore(f => f.Conclusions);
            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.CreatedBy);
            descriptor.Ignore(f => f.LastModified);
            descriptor.Ignore(f => f.LastModifiedBy);
        }
    }
}