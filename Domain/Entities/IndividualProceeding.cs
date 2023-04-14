﻿using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Domain.Support;

namespace Domain.Entities
{
    public class IndividualProceeding : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid ReceptionDocumentId { get; private set; }
        public int StatusId { get; private set; }
        public int CategoryId { get; private set; }
        public Guid? AnimalChipId { get; private set; }
        //public Guid MedicalRecordId { get; private set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        
        /// Revisar las propiedades de navegacion en caso de que una entidad/valueobject sea relacionada.
        public virtual ReceptionDocument ReceptionDocument { get; set; } = null!;
        public virtual ProceedingStatus ProceedingStatus { get; set; } = null!;
        public virtual AnimalCategory AnimalCategory { get; private set; } = null!;
        public virtual AnimalChip? AnimalChip { get; private set; } = null!;


        /// <summary>
        /// 
        /// </summary>
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
        private IndividualProceeding(Guid id, Guid receptionDocumentId, int status, int animalCategory, Guid? animalChipId) : base(id)
        {
            ReceptionDocumentId = receptionDocumentId;
            StatusId = status;
            CategoryId = animalCategory;
            AnimalChipId = animalChipId;
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
            int status,
            int animalCategory, 
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
