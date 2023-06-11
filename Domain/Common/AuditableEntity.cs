namespace Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Creation actor.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Last modification date.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Last modifier actor.
        /// </summary>
        public string? LastModifiedBy { get; set; }

        /// <summary>
        /// Entity constructor that initializes its identifier
        /// </summary>
        /// <param name="id">Entity identifier</param>
        protected AuditableEntity(Guid id) : base(id)
        {
            Id = id;
        }
    }
}
