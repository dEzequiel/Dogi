using Domain.ValueObjects;

namespace Api.GraphQL.InputObjectTypes.Adoption;

public class PersonalReferenceInputType : InputObjectType<PersonalReference>
{
    protected override void Configure(IInputObjectTypeDescriptor<PersonalReference> descriptor)
    {
        base.Configure(descriptor);
    }
}