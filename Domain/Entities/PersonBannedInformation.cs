using Domain.Common;

namespace Domain.Entities
{
    public class PersonBannedInformation : AuditableEntity
    {

        public string PersonIdentifierId {get; set;}= null!;
        public string? Observations { get; set; }

        public PersonBannedInformation(Guid id) : base(id)
        {
        }

        public PersonBannedInformation(Guid id, string personIdentifierId, string? observations) : base(id)
        {
            PersonIdentifierId = personIdentifierId;
            Observations = observations;
        }

        public virtual Person Person {get; set; }   

    }
}