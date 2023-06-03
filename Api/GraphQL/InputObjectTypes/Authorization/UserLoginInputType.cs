using Crosscuting.Api.DTOs.Authentication;

namespace Api.GraphQL.InputObjectTypes.Authorization;

public class UserLoginInputType : InputObjectType<UserDataLogin>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserDataLogin> descriptor)
    {
    }
}