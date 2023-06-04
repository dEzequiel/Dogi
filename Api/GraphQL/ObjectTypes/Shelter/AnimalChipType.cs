﻿using Domain.Entities.Shelter;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    public class AnimalChipType : ObjectType<AnimalChip>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimalChip> descriptor)
        {
            descriptor.Field(f => f.Id).Type<NonNullType<UuidType>>();
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.ChipNumber).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.OwnerIsResponsible).Type<NonNullType<StringType>>();

            descriptor.Ignore(f => f.PersonIdentifierId);
            descriptor.Ignore(f => f.ReceptionDocumentId);
        }
    }
}