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

            descriptor
            .Field(f => f.Owner)
            .Type<NonNullType<AnimalChipOwnerInput>>();

            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.CreatedBy);
            descriptor.Ignore(f => f.LastModified);
            descriptor.Ignore(f => f.LastModifiedBy);
        }
    }
}
