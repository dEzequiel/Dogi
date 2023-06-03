using Api.GraphQL.InputObjectTypes.Shelter;
using Crosscuting.Api.DTOs.Authentication;

namespace Api.GraphQL.InputObjectTypes.Authorization;

public class UserRegisterInputType : InputObjectType<UserDataRegister>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserDataRegister> descriptor)
    {
        descriptor.Field(f => f.Person)
            .Type<NonNullType<PersonInputType>>();
    }
}