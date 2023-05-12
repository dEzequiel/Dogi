using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    public class AnimalChipInput : InputObjectType<AnimalChip>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnimalChip> descriptor)
        {
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
