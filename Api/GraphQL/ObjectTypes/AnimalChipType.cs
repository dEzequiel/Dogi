using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    public class AnimalChipType : ObjectType<AnimalChip>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimalChip> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<NonNullType<UuidType>>();

            descriptor
                .Field(f => f.OwnerPersonalIdentifier)
                .Type<NonNullType<StringType>>();

            descriptor
                .Field(f => f.Name)
                .Type<StringType>();

            descriptor
                .Field(f => f.ChipNumber) 
                .Type<NonNullType<StringType>>();


            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.CreatedBy);
            descriptor.Ignore(f => f.LastModified);
            descriptor.Ignore(f => f.LastModifiedBy);
        }
    }
}
