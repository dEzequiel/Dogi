using Domain.ValueObjects;

namespace Api.GraphQL.InputObjectTypes.Adoption;

public class OtherAnimalInputType : InputObjectType<OtherAnimal>
{
    protected override void Configure(IInputObjectTypeDescriptor<OtherAnimal> descriptor)
    {
        base.Configure(descriptor);
    }
}