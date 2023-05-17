using Domain.Common;

namespace Domain.Entities
{
    public class PersonBannedInformation : AuditableEntity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string PersonIdentifierId {get; set;}= null!;
        public string? Observations { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual Person Person {get; set; }  = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personIdentifierId"></param>
        /// <param name="observations"></param> 

        public PersonBannedInformation(Guid id) : base(id)
        {
        }

        public PersonBannedInformation(Guid id, string personIdentifierId, string? observations) : base(id)
        {
            PersonIdentifierId = personIdentifierId;
            Observations = observations;
        }
    }
}