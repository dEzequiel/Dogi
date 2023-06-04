using Domain.ValueObjects;

namespace Api.GraphQL.InputObjectTypes.Adoption;

public class HouseDescriptionInputType : InputObjectType<House>
{
    protected override void Configure(IInputObjectTypeDescriptor<House> descriptor)
    {
        base.Configure(descriptor);
    }
}