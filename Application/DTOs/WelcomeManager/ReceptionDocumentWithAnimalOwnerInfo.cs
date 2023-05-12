using Domain.Entities;

namespace Application.DTOs.WelcomeManager
{
    public class ReceptionDocumentWithAnimalOwnerInfo
    {
        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public AnimalChip? AnimalChip { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocument"></param>
        /// <param name="animalChipOwner"></param>
        /// <param name="animalChip"></param>
        public ReceptionDocumentWithAnimalOwnerInfo(ReceptionDocument receptionDocument, AnimalChip? animalChip)
        {
            ReceptionDocument = receptionDocument;
            AnimalChip = animalChip;
        }

        public ReceptionDocumentWithAnimalOwnerInfo()
        {
        }
    }
}
