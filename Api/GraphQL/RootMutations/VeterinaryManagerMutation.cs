using Application.DTOs.VeterinaryManager;
using Domain.Entities;

namespace Api.GraphQL.RootMutations
{
    public partial class Mutation
    {
        /// <summary>
        /// 
        /// </summary>
        public IndividualProceedingWithMedicalRecord CheckMedicalRecord { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public IndividualProceedingWithMedicalRecord CloseMedicalRecord { get; set; } = null!;


        /// <summary>
        /// 
        /// </summary>
        public IndividualProceedingWithVaccinationCard AssignVaccine { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public VaccinationCardVaccine Vaccine { get; set; } = null!;
    }
}
