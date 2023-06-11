using Domain.Entities.Shelter;

namespace Application.DTOs.WelcomeManager
{
    public class RegisterInformation
    {
        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public IndividualProceeding IndividualProceeding { get; set; }
        public AnimalChip? AnimalChip { get; set; }
        public Person? Person { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocument"></param>
        /// <param name="individualProceeding"></param>
        /// <param name="animalChip"></param>
        public RegisterInformation(ReceptionDocument receptionDocument, IndividualProceeding individualProceeding,
            AnimalChip? animalChip, Person? person)
        {
            ReceptionDocument = receptionDocument;
            IndividualProceeding = individualProceeding;
            AnimalChip = animalChip;
            Person = person;
        }

        public RegisterInformation()
        {
        }
    }
}