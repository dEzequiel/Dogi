using Domain.Common;
using Domain.Support;

namespace Domain.Entities
{
    public class IndividualProceeding : AuditableEntity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid ReceptionDocumentId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Color { get; set; }
        public int StatusId { get; set; }
        //public Guid MedicalRecordId { get; private set; }
        public int CategoryId { get; set; }
        public int SexId { get; set; }
        public Guid CageId { get; set; }
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual ReceptionDocument ReceptionDocument { get; set; } = null!;
        public virtual ProceedingStatus ProceedingStatus { get; set; } = null!;
        public virtual AnimalCategory AnimalCategory { get; set; } = null!;
        public virtual Sex Sex { get; set; } = null!;
        public virtual AnimalZone AnimalZone { get; set; } = null!;
        public virtual Cage Cage { get; set; } = null!;

        public IndividualProceeding(Guid id) : base(id) { }
        public IndividualProceeding() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocumentId"></param>
        /// <param name="statusId"></param>
        /// <param name="categoryId"></param>
        /// <param name="sexId"></param>
        /// <param name="cageId"></param>
        /// <param name="isDeleted"></param>
        public IndividualProceeding(Guid id,
            Guid receptionDocumentId,
            int statusId,
            int categoryId,
            int sexId,
            bool isDeleted,
            Guid cageId) : base(id)
        {
            StatusId = statusId;
            CategoryId = categoryId;
            SexId = sexId;
            IsDeleted = isDeleted;
            CageId = cageId;
        }
    }
}
