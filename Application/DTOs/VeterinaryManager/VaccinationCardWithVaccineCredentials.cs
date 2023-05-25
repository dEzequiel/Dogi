namespace Application.DTOs.VeterinaryManager
{
    public class VaccinationCardWithVaccineCredentials
    {
        public Guid VaccinationCardId { get; set; }
        public Guid VaccineId { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccineId"></param>
        public VaccinationCardWithVaccineCredentials(Guid vaccinationCardId, Guid vaccineId)
        {
            VaccinationCardId = vaccinationCardId;
            VaccineId = vaccineId;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public VaccinationCardWithVaccineCredentials() { }
    }
}
