using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Domain.Support;

namespace Domain.Entities
{
    public class IndividualProceeding : AuditableEntity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid ReceptionDocumentId { get; set; }
        public int StatusId { get; set; }
        //public Guid MedicalRecordId { get; private set; }
        public Guid CategoryId { get; set; }
        public int SexId { get; set; }
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual ReceptionDocument ReceptionDocument { get; set; } = null!;
        public virtual ProceedingStatus ProceedingStatus { get; set; } = null!;
        public virtual AnimalCategory AnimalCategory { get; set; }
        public virtual Sex Sex { get; set; }


        public IndividualProceeding(Guid id) : base(id) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocumentId"></param>
        /// <param name="statusId"></param>
        /// <param name="categoryId"></param>
        /// <param name="sexId"></param>
        /// <param name="isDeleted"></param>
        public IndividualProceeding(Guid receptionDocumentId, int statusId, Guid categoryId, 
            int sexId, bool isDeleted) : this(receptionDocumentId)
        {
            StatusId = statusId;
            CategoryId = categoryId;
            SexId = sexId;
            IsDeleted = isDeleted;
        }
    }
}
