

using Domain.Entities;

namespace Application.DTOs.VeterinaryManager
{
    public class IndividualProceedingWithVaccinationCard
    {
        public IndividualProceeding IndividualProceeding { get; set; } = null!;
        public VaccinationCard VaccinationCard { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="individualProceeding"></param>
        /// <param name="vaccinationCard"></param>
        public IndividualProceedingWithVaccinationCard(IndividualProceeding individualProceeding, VaccinationCard vaccinationCard)
        {
            IndividualProceeding = individualProceeding;
            VaccinationCard = vaccinationCard;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public IndividualProceedingWithVaccinationCard() { }
    }
}
