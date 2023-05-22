using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    public class AnimalChipInput : InputObjectType<AnimalChip>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnimalChip> descriptor)
        {
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.ChipNumber).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.OwnerIsResponsible).Type<NonNullType<BooleanType>>();

            descriptor.Ignore(f => f.Id);
        }
    }
}
