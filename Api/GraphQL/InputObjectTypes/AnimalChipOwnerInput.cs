using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    /// <summary>
    /// AnimalChipOwner input type for graphql mutations.
    /// </summary>
    public class AnimalChipOwnerInput : InputObjectType<AnimalChipOwner>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnimalChipOwner> descriptor)
        {
            descriptor.Field(f => f.Name)
                .Type<StringType>();

            descriptor.Field(f => f.Lastname)
                .Type<NonNullType<StringType>>();


            descriptor.Field(f => f.Address)
                .Type<NonNullType<StringType>>();


            descriptor.Field(f => f.IsResponsible)
                .Type<NonNullType<BooleanType>>();


        }
    }
}
