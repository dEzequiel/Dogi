using Application.DTOs.VeterinaryManager;

namespace Api.GraphQL.RootMutations
{
    public partial class Mutation
    {
        /// <summary>
        /// 
        /// </summary>
        public InvidiualProceedingWithMedicalRecord CheckMedicalRecord { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public IndividualProceedingWithVaccinationCard AssignVaccine { get; set; } = null!;
    }
}
