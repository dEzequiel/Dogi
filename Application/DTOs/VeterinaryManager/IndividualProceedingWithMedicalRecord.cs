using Domain.Entities;
using Domain.Entities.Shelter;

namespace Application.DTOs.VeterinaryManager
{
    public class IndividualProceedingWithMedicalRecord
    {
        public IndividualProceeding IndividualProceeding { get; set; } = null!;
        public MedicalRecord MedicalRecord { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="individualProceeding"></param>
        /// <param name="medicalRecord"></param>
        public IndividualProceedingWithMedicalRecord(IndividualProceeding individualProceeding,
            MedicalRecord medicalRecord)
        {
            IndividualProceeding = individualProceeding;
            MedicalRecord = medicalRecord;
        }

        public IndividualProceedingWithMedicalRecord()
        {
        }
    }
}