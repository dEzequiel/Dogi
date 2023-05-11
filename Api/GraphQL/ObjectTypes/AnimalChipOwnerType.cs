using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    public class AnimalChipOwnerType : ObjectType<AnimalChipOwner>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimalChipOwner> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<NonNullType<UuidType>>();

            descriptor
                .Field(f => f.Name)
                .Type<StringType>();

            descriptor
                .Field(f => f.Lastname)
                .Type<StringType>();

            descriptor
                .Field(f => f.IsResponsible)
                .Type<BooleanType>();

            descriptor
                .Field(f => f.Address)
                .Type<AddressType>();
           
        }
    }
}
