using Domain.Common;
using Domain.Support;

namespace Domain.Entities
{
    public class MedicalRecord : AuditableEntity
    {
        /// <summary>
        /// Individual proceedign identifier which medical record belongs.
        /// </summary>
        public Guid IndividualProceedingId { get; set; }
        /// <summary>
        /// Medical record status identifier.
        /// </summary>
        public int MedicalStatusId { get; set; }
        /// <summary>
        /// Medical record causes.
        /// </summary>
        public string Causes { get; set; }
        /// <summary>
        /// Medical record observations.
        /// </summary>
        public string? Observations { get; set; }
        /// <summary>
        /// Medical record final conclusions
        /// </summary>
        public string? Conclusions { get; set; }

        /// <summary>
        /// Individual relationship.
        /// </summary>
        public virtual IndividualProceeding IndividualProceeding { get; set; } = null!;
        /// <summary>
        /// MedicalRecordStatus relationship.
        /// </summary>
        public virtual MedicalRecordStatus MedicalRecordStatus { get; set; } = null!;
        /// <summary>
        /// Vaccines relationship.
        /// </summary>
        public virtual ICollection<Vaccine>? Vaccines { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicalStatusId"></param>
        /// <param name="observations"></param>
        /// <param name="conclusions"></param>
        /// <param name="individualProceedingId"></param>
        public MedicalRecord(Guid id,
            Guid individualProceedingId,
            int medicalStatusId,
            string causes,
            string? observations,
            string? conclusions) : base(id)
        {
            IndividualProceedingId = individualProceedingId;
            MedicalStatusId = medicalStatusId;
            Causes = causes;
            Observations = observations;
            Conclusions = conclusions;
        }


        public MedicalRecord(Guid id) : base(id) { }

        public MedicalRecord() : base(Guid.NewGuid()) { }
    }
}
