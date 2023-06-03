using Crosscuting.Api;

namespace Api.GraphQL.InputObjectTypes.Authorization;

public class UserInput : InputObjectType<UserDataRegister>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserDataRegister> descriptor)
    {
    }
}