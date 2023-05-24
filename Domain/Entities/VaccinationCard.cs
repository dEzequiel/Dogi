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
        public List<Vaccine> Vaccines { get; } = new();
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
        public VaccinationCard(Guid id) : base(id)
        {
        }
    }
}
