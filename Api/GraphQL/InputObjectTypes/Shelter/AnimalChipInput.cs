﻿using Domain.Entities.Shelter;

namespace Api.GraphQL.InputObjectTypes.Shelter
{
    public class AnimalChipInput : InputObjectType<AnimalChip>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnimalChip> descriptor)
        {
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.ChipNumber).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.OwnerIsResponsible).Type<NonNullType<BooleanType>>();

            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.PersonIdentifierId);
            descriptor.Ignore(f => f.ReceptionDocumentId);
            descriptor.Ignore(f => f.Person);
            descriptor.Ignore(f => f.ReceptionDocument);
        }
    }
}