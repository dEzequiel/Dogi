using Domain.Common;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Exceptions.Result;

namespace Domain.Entities
{
    public class IndividualProceeding : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid ReceptionDocumentId { get; private set; }
        public IndividualProceedingStatus Status { get; private set; }
        public AnimalCategory AnimalCategory { get; private set; }
        public Guid? AnimalChipId { get; private set; }
        //public Guid MedicalRecordId { get; private set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        
        /// Revisar las propiedades de navegacion en caso de que una entidad/valueobject sea relacionada.

        public virtual ReceptionDocument ReceptionDocument { get; set; } = null!;
        public virtual Animal Animal { get; private set; } = null!;
        
        public IndividualProceeding(Guid id) : base(id) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="receptionDocumentId"></param>
        /// <param name="status"></param>
        /// <param name="animalCategory"></param>
        /// <param name="animallChipId"></param>
        public IndividualProceeding(Guid id, Guid receptionDocumentId, IndividualProceedingStatus status, AnimalCategory animalCategory, Guid? animallChipId) : base(id)
        {
            ReceptionDocumentId = receptionDocumentId;
            Status = status;
            AnimalCategory = animalCategory;
            AnimalChipId = animallChipId;
        }

        /// <summary>
        /// Static Factory Pattern. Creates new IndividualProcess in valid state.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="receptionDocumentId"></param>
        /// <param name="status"></param>
        /// <param name="animalCategory"></param>
        /// <param name="animalChipId"></param>
        /// <returns></returns>
        public static Result<IndividualProceeding> Create(
            Guid id,
            Guid receptionDocumentId,
            IndividualProceedingStatus status,
            AnimalCategory animalCategory, 
            Guid? animalChipId)
        {
            if (id == Guid.Empty)
                return Result.Failure<IndividualProceeding>(DomainErrors.IndividualProceeding.IndividualProcessIdIsNullOrEmpty);

            if(receptionDocumentId == Guid.Empty)
                return Result.Failure<IndividualProceeding>(DomainErrors.IndividualProceeding.IndividualProcessReceptionDocumentIdIsNullOrEmpty);

            return new IndividualProceeding(id, receptionDocumentId, status, animalCategory, animalChipId);

        }
    }
}
