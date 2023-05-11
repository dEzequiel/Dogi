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
              .Type<ReceptionDocumentInputType>();

            descriptor.Field(f => f.AnimalChipOwner)
                .Type<AnimalChipOwnerInputType>();

        }
    }
}
