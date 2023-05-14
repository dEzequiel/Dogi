using Application.DTOs.WelcomeManager;

namespace Api.GraphQL.RootMutations
{
    /// <summary>
    /// Partial class part representing WelcomeManager usable mutations.
    /// </summary>
    public partial class Mutation 
    {
        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition you take one way or the other.
        /// </summary>
        public ReceptionDocumentWithAnimalInformation RegiterNewAnimal { get; set; } = null!;
    }
}
