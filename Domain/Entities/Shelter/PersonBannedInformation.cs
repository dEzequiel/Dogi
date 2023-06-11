using Domain.Common;

namespace Domain.Entities.Shelter
{
    /// <summary>
    /// Person ban information.
    /// </summary>
    public class PersonBannedInformation : AuditableEntity
    {
        /// <summary>
        /// PersonIdentifier Id.
        /// </summary>
        public string PersonIdentifierId { get; set; } = null!;

        /// <summary>
        /// Person Banned Observations.
        /// </summary>
        public string? Observations { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual Person Person { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personIdentifierId"></param>
        /// <param name="observations"></param>
        public PersonBannedInformation(Guid id, string personIdentifierId, string? observations) : base(id)
        {
            PersonIdentifierId = personIdentifierId;
            Observations = observations;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public PersonBannedInformation(Guid id) : base(id)
        {
        }
    }
}