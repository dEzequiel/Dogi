using Api.GraphQL.InputObjectTypes.Shelter;
using Crosscuting.Api;

namespace Api.GraphQL.InputObjectTypes.Authorization;

public class UserInputType : InputObjectType<UserDataRegister>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserDataRegister> descriptor)
    {
        descriptor.Field(f => f.Person)
            .Type<NonNullType<PersonInputType>>();
    }
}