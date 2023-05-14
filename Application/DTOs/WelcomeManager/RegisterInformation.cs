using Domain.Entities;

namespace Application.DTOs.WelcomeManager
{
    public class RegisterInformation
    {
        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public IndividualProceeding? IndividualProceeding { get; set; }
        public AnimalChip? AnimalChip { get; set; }

        public RegisterInformation() {}

        public RegisterInformation(ReceptionDocument receptionDocument, IndividualProceeding? individualProceeding)
        {
            ReceptionDocument = receptionDocument;
            IndividualProceeding = individualProceeding;
        }

        public RegisterInformation(ReceptionDocument receptionDocument, AnimalChip? animalChip)
        {
            ReceptionDocument = receptionDocument;
            AnimalChip = animalChip;
        }
    }
}