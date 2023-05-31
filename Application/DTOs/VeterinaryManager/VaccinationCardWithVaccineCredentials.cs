namespace Application.DTOs.VeterinaryManager
{
    public class VaccinationCardWithVaccineCredentials
    {
        public Guid VaccinationCardId { get; set; }
        public VaccinesToComplish VaccinesToComplishIds { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccineId"></param>
        public VaccinationCardWithVaccineCredentials(Guid vaccinationCardId, VaccinesToComplish vaccinesToComplishIds)
        {
            VaccinationCardId = vaccinationCardId;
            VaccinesToComplishIds = vaccinesToComplishIds;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public VaccinationCardWithVaccineCredentials() { }
    }
}
