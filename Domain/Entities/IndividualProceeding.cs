using Domain.Common;
using Domain.Support;

namespace Domain.Entities
{
    /// <summary>
    /// Represents an animal in the shelter.
    /// </summary>
    public class IndividualProceeding : AuditableEntity
    {
        /// <summary>
        /// Nested reception document when animal first arrives.  
        /// </summary>
        public Guid ReceptionDocumentId { get; set; }
        /// <summary>
        /// Animal name.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Animal age.
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// Animal color.
        /// </summary>
        public string? Color { get; set; }
        /// <summary>
        /// Animal status.
        /// </summary>
        public int StatusId { get; set; }
        //public Guid MedicalRecordId { get; private set; }
        /// <summary>
        /// AnIMAL category.
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Animal sex.
        /// </summary>
        public int SexId { get; set; }
        /// <summary>
        /// Animal cage.
        /// </summary>
        public Guid CageId { get; set; }
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Navigation properties.
        /// </summary>

        /// <summary>
        /// Animal reception document.
        /// </summary>
        public virtual ReceptionDocument ReceptionDocument { get; set; } = null!;
        /// <summary>
        /// Animal status.
        /// </summary>
        public virtual ProceedingStatus ProceedingStatus { get; set; } = null!;
        /// <summary>
        /// Animal category.
        /// </summary>
        public virtual AnimalCategory AnimalCategory { get; set; } = null!;
        /// <summary>
        /// Animal sex.
        /// </summary>
        public virtual Sex Sex { get; set; } = null!;
        /// <summary>
        /// Animal cage.
        /// </summary>
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
