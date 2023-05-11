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
                .Field(f => f.ChipNumber) 
                .Type<NonNullType<StringType>>();

            descriptor
                .Field(f => f.AnimalChipOwnerId) 
                .Type<NonNullType<UuidType>>();

            descriptor.Ignore(f => f.AnimalChipOwner);
            descriptor.Ignore(f => f.IndividualProceeding);


        }
    }
}
