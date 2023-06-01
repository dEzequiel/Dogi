using Crosscuting.Api;

namespace Api.GraphQL.InputObjectTypes;

public class UserInput : InputObjectType<UserDataRegister>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserDataRegister> descriptor)
    {
    }
}