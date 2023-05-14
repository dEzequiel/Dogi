using Domain.Entities;

namespace Application.DTOs.WelcomeManager
{
    public class ReceptionDocumentWithAnimalInformation
    {
        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public AnimalChip? AnimalChip { get; set; }
        public IndividualProceeding? IndividualProceeding { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocument"></param>
        /// <param name="animalChip"></param>
        /// <param name="individualProceeding"></param>
        public ReceptionDocumentWithAnimalInformation(ReceptionDocument receptionDocument, AnimalChip? animalChip, IndividualProceeding? individualProceeding)
        {
            ReceptionDocument = receptionDocument;
            AnimalChip = animalChip;
            IndividualProceeding = individualProceeding;
        }

        public ReceptionDocumentWithAnimalInformation()
        {
        }
    }
}
