namespace Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        protected AuditableEntity(Guid id) : base(id)
        {
        }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
