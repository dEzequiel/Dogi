namespace Application.DTOs.VeterinaryManager
{
    public class IndividualProceedingAndMedicalRecordCredentials
    {
        public Guid IndividualProceedingId { get; set; }

        public Guid MedicalRecordId { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="individualProceedingId"></param>
        /// <param name="medicalRecordId"></param>
        public IndividualProceedingAndMedicalRecordCredentials(Guid individualProceedingId, Guid medicalRecordId)
        {
            IndividualProceedingId = individualProceedingId;
            MedicalRecordId = medicalRecordId;
        }

        public IndividualProceedingAndMedicalRecordCredentials() { }
    }
}
