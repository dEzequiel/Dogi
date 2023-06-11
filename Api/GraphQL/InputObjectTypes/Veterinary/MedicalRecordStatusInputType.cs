using Api.GraphQL.EnumType;

namespace Api.GraphQL.InputObjectTypes.Veterinary;

public class MedicalRecordStatusInputType : InputObjectType
{
    protected override void Configure(IInputObjectTypeDescriptor descriptor)
    {
        descriptor.Field("status").Type<NonNullType<MedicalRecordStatusEnumType>>();
    }
}