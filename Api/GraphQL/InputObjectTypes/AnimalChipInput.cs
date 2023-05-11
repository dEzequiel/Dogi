using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    public class AnimalChipInput : InputObjectType<AnimalChip>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnimalChip> descriptor)
        {
            descriptor.Field(f => f.AnimalChipOwnerId)
                .Type<UuidType>(); 

            descriptor.Field(f => f.ChipNumber)
                .Type<StringType>();


        }
    }
}
