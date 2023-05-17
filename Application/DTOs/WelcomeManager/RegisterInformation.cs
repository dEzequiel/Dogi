using Domain.Entities;

namespace Application.DTOs.WelcomeManager
{
    public class RegisterInformation
    {
        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public IndividualProceeding IndividualProceeding { get; set; }
        public AnimalChip? AnimalChip { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocument"></param>
        /// <param name="individualProceeding"></param>
        /// <param name="animalChip"></param>
        public RegisterInformation(ReceptionDocument receptionDocument, IndividualProceeding individualProceeding, AnimalChip? animalChip)
        {
            ReceptionDocument = receptionDocument;
            IndividualProceeding = individualProceeding;
            AnimalChip = animalChip;
        }

        public RegisterInformation() {}


    }
}