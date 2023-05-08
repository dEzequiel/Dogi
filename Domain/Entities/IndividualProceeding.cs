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
        public Guid AnimalId { get; private set; }
        public Guid ReceptionDocumentId { get; private set; }
        public int StatusId { get; private set; }
        public bool IsDeleted { get; set; }
        //public Guid MedicalRecordId { get; private set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual Animal Animal { get; set; } = null!;
        public virtual ReceptionDocument ReceptionDocument { get; set; } = null!;
        public virtual ProceedingStatus ProceedingStatus { get; set; } = null!;

        public IndividualProceeding(Guid id) : base(id) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animalId"></param>
        /// <param name="receptionDocumentId"></param>
        /// <param name="status"></param>
        private IndividualProceeding(Guid id, Guid animalId, Guid receptionDocumentId, int status) : base(id)
        {
            AnimalId = animalId;
            ReceptionDocumentId = receptionDocumentId;
            StatusId = status;
        }

        /// <summary>
        /// Static Factory Pattern. Creates new IndividualProcess in valid state.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animalId"></param>
        /// <param name="receptionDocumentId"></param>
        /// <param name="status"></param>
        /// <param name="animalCategory"></param>
        /// <param name="animalChipId"></param>
        /// <returns></returns>
        public static Result<IndividualProceeding> Create(
            Guid id,
            Guid animalId,
            Guid receptionDocumentId,
            int status)
        {
            if (id == Guid.Empty)
                return Result.Failure<IndividualProceeding>(DomainErrors.IndividualProceeding
                                                                            .IndividualProcessIdIsNullOrEmpty);

            if(receptionDocumentId == Guid.Empty)
                return Result.Failure<IndividualProceeding>(DomainErrors.IndividualProceeding
                                                                            .IndividualProcessReceptionDocumentIdIsNullOrEmpty);

            return new IndividualProceeding(id, animalId, receptionDocumentId, status);

        }
    }
}
