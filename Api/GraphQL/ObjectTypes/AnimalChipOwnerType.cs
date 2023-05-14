using Domain.ValueObjects;

namespace Api.GraphQL.ObjectTypes
{
    public class AnimalChipOwnerType : ObjectType<AnimalChipOwner>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimalChipOwner> descriptor)
        {
            descriptor.
                Field(f => f.Name)
                .Type<StringType>();

            descriptor.
                Field(f => f.Lastname)
                .Type<StringType>();

            descriptor.
                Field(f => f.Contact)
                .Type<StringType>();
            
            descriptor.
                Field(f => f.Address)
                .Type<AddressType>();
            
            descriptor.
                Field(f => f.IsResponsible)
                .Type<NonNullType<BooleanType>>();
        }
    }
}