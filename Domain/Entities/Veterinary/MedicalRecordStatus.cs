using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Suport table representing records equivalent to MedicalRecordStatus domain enumerator.
    /// </summary>
    public class MedicalRecordStatus
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Collection of Medical record relationships.
        /// </summary>
        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public MedicalRecordStatus(int id, string status)
        {
            Id = id;
            Status = status;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MedicalRecordStatus()
        {
        }
    }
}