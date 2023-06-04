using Domain.Common;
using Domain.Support;

namespace Domain.Entities
{
    /// <summary>
    /// Represents the collection of vaccines that an animal has received.
    /// </summary>
    public class VaccinationCardVaccine : AuditableEntity
    {
        /// <summary>
        /// Vaccine identifier.
        /// </summary>
        public Guid VaccineId { get; set; }

        /// <summary>
        /// Vaccine card identifier
        /// </summary>
        public Guid VaccinationCardId { get; set; }

        /// <summary>
        /// Vaccine status identifier.
        /// </summary>
        public int VaccineStatusId { get; set; }

        /// <summary>
        /// Vaccine start date.
        /// </summary>
        public DateTime? VaccineStart { get; set; }

        /// <summary>
        /// Vaccine end date.
        /// </summary>
        public DateTime? VaccineEnd { get; set; }

        /// <summary>
        /// Veterinary identifier.
        /// </summary>
        //public Guid VeterinaryId { get; set; }

        /// <summary>
        /// Vaccine status relationship.
        /// </summary>
        public virtual Vaccine Vaccine { get; set; } = null!;

        /// <summary>
        /// Vaccination card relationship.
        /// </summary>
        public virtual VaccinationCard VaccinationCard { get; set; } = null!;

        /// <summary>
        /// Vaccine status relationship.
        /// </summary>
        public virtual VaccineStatus VaccineStatus { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vaccineId"></param>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccineStatusId"></param>
        /// <param name="vaccineStart"></param>
        /// <param name="vaccineEnd"></param>
        public VaccinationCardVaccine(Guid id, Guid vaccineId, Guid vaccinationCardId, int vaccineStatusId,
            DateTime? vaccineStart, DateTime? vaccineEnd) : base(id)
        {
            VaccinationCardId = vaccinationCardId;
            VaccineStatusId = vaccineStatusId;
            VaccineStart = vaccineStart;
            VaccineEnd = vaccineEnd;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public VaccinationCardVaccine(Guid id) : base(id)
        {
        }

        public VaccinationCardVaccine() : base(Guid.NewGuid())
        {
        }
    }
}