using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records equivalent to VaccineStatus domain enumerator.
    /// </summary>
    public class VaccineStatus
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Collection of VaccinationCardVaccine relationships.
        /// </summary>
        public virtual ICollection<VaccinationCardVaccine> VaccinationCardVaccines { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public VaccineStatus(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
