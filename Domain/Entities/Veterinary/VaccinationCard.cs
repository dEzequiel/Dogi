using Domain.Common;
using Domain.Entities.Shelter;

namespace Domain.Entities
{
    /// <summary>
    /// Represents animal vaccination card.
    /// </summary>
    public class VaccinationCard : AuditableEntity
    {
        /// <summary>
        /// Vaccination Card extra observations.
        /// </summary>
        public string? Observations { get; set; }

        /// <summary>
        /// VaccinationCardVaccine collection relationship. 
        /// </summary>
        public virtual ICollection<VaccinationCardVaccine>? VaccinationCardVaccines { get; set; }

        /// <summary>
        /// IndividualProceeding relationship.
        /// </summary>
        public virtual IndividualProceeding? IndividualProceeding { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="observations"></param>
        public VaccinationCard(Guid id, string? observations) : base(id)
        {
            Observations = observations;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="vaccinationCardVaccines"></param>
        public VaccinationCard(Guid id, string? observations,
            ICollection<VaccinationCardVaccine>? vaccinationCardVaccines) : base(id)
        {
            Observations = observations;
            VaccinationCardVaccines = vaccinationCardVaccines;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public VaccinationCard(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public VaccinationCard() : base(Guid.NewGuid())
        {
        }
    }
}