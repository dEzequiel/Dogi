using Crosscuting.Api;

namespace Api.GraphQL.InputObjectTypes;

public class UserInput : InputObjectType<UserData>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserData> descriptor)
    {
    }
}