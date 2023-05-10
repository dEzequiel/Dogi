using Domain.Entities;
using Domain.ValueObjects;

namespace Application.DTOs.WelcomeManager
{
    public class ReceptionDocumentWithAnimalOwnerInfo
    {
        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public AnimalChipOwner? AnimalChipOwner { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocument"></param>
        /// <param name="animalChipOwner"></param>
        public ReceptionDocumentWithAnimalOwnerInfo(ReceptionDocument receptionDocument, AnimalChipOwner? animalChipOwner)
        {
            ReceptionDocument = receptionDocument;
            AnimalChipOwner = animalChipOwner;
        }

        public ReceptionDocumentWithAnimalOwnerInfo()
        {
        }
    }
}
