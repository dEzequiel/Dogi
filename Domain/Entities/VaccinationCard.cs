using Domain.Common;

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
        /// Vaccines collection relationship. 
        /// </summary>
        public virtual ICollection<Vaccine>? Vaccines { get; set; }
        /// <summary>
        /// IndividualProceeding relationship.
        /// </summary>
        public IndividualProceeding IndividualProceeding { get; set; } = null!;

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
        /// <param name="id"></param>
        /// <param name="observations"></param>
        /// <param name="vaccines"></param>
        public VaccinationCard(Guid id, string? observations, List<Vaccine> vaccines) : base(id)
        {
            Observations = observations;
            Vaccines = vaccines;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public VaccinationCard(Guid id) : base(id) { }
        /// <summary>
        /// Constructor.
        /// </summary>
        public VaccinationCard() : base(Guid.NewGuid()) { }
    }
}
