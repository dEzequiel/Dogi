﻿using Api.GraphQL.ObjectTypes;
using Application.DTOs.WelcomeManager;

namespace Api.GraphQL.InputObjectTypes
{
    /// <summary>
    /// ReceptionDocumentWithAnimalChipOwnerInfoInput input type for graphql mutations.
    /// </summary>
    public class RegisterAnimalHostInput : InputObjectType<RegisterInformation>
    {
        protected override void Configure(IInputObjectTypeDescriptor<RegisterInformation> descriptor)
        {
            descriptor.Field(f => f.ReceptionDocument)
              .Type<NonNullType<ReceptionDocumentInput>>();

            descriptor.Field(f => f.IndividualProceeding)
                .Type<NonNullType<IndividualProceedingInput>>();

            descriptor.Field(f => f.AnimalChip)
                .Type<AnimalChipInput>();



        }
    }
}
