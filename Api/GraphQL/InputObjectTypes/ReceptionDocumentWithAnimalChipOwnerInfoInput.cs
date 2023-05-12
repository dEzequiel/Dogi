using Api.GraphQL.ObjectTypes;
using Application.DTOs.WelcomeManager;

namespace Api.GraphQL.InputObjectTypes
{
    /// <summary>
    /// ReceptionDocumentWithAnimalChipOwnerInfoInput input type for graphql mutations.
    /// </summary>
    public class ReceptionDocumentWithAnimalChipOwnerInfoInput : InputObjectType<ReceptionDocumentWithAnimalOwnerInfo>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReceptionDocumentWithAnimalOwnerInfo> descriptor)
        {
            descriptor.Field(f => f.ReceptionDocument)
              .Type<ReceptionDocumentInput>();


            descriptor.Field(f => f.AnimalChip)
                .Type<AnimalChipInput>();

        }
    }
}
