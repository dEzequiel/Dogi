using Domain.Entities;

namespace Api.GraphQL.RootMutations
{
    /// <summary>
    /// Partial class part representing VaccineMutation usable mutations.
    /// </summary>
    public partial class Mutation
    {
        public IEnumerable<Vaccine> AddVaccine { get; set; } = null!;

    }
}
