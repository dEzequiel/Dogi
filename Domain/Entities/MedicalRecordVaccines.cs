using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// Represents the collection of vaccines that comes with an medical record.
    /// </summary>
    public class MedicalRecordVaccines : Entity
    {
        /// <summary>
        /// Medical record identifier.
        /// </summary>
        public Guid MedicalRecordId { get; set; }
        /// <summary>
        /// Vaccine identifier.
        /// </summary>
        public Guid VaccineId { get; set; }

        /// <summary>
        /// Medical record relationship.
        /// </summary>
        public virtual MedicalRecord MedicalRecord { get; set; }
        /// <summary>
        /// Vaccine relationship.
        /// </summary>
        public virtual Vaccine Vaccine { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicalRecordId"></param>
        /// <param name="vaccineId"></param>
        public MedicalRecordVaccines(Guid id, Guid medicalRecordId, Guid vaccineId) : base(id)
        {
            MedicalRecordId = medicalRecordId;
            VaccineId = vaccineId;
        }

        public MedicalRecordVaccines(Guid id) : base(id) { }
        public MedicalRecordVaccines() : base(Guid.NewGuid()) { }

    }
}
