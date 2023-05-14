using Domain.ValueObjects;

namespace Api.GraphQL.InputObjectTypes
{
    public class AnimalChipOwnerInput : InputObjectType<AnimalChipOwner>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnimalChipOwner> descriptor)
        {
            descriptor
                .Field(f => f.Name)
                .Type<StringType>();

            descriptor
                .Field(f => f.Lastname)
                .Type<StringType>();

            descriptor
                .Field(f => f.Contact)
                .Type<StringType>();
            
            descriptor
                .Field(f => f.Address)
                .Type<AddressInput>();
            
            descriptor
                .Field(f => f.IsResponsible)
                .Type<NonNullType<BooleanType>>();
        }
    }
}