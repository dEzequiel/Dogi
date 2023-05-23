using Domain.Entities;

namespace Application.DTOs.VeterinaryManager
{
    public class InvidiualProceedingWithMedicalRecord
    {
        public IndividualProceeding IndividualProceeding { get; set; } = null!;
        public MedicalRecord MedicalRecord { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="individualProceeding"></param>
        /// <param name="medicalRecord"></param>
        public InvidiualProceedingWithMedicalRecord(IndividualProceeding individualProceeding, MedicalRecord medicalRecord)
        {
            IndividualProceeding = individualProceeding;
            MedicalRecord = medicalRecord;
        }

        public InvidiualProceedingWithMedicalRecord()
        {
        }
    }
}
