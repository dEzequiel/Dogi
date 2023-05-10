using Domain.Entities;
using Domain.ValueObjects;

namespace Api.DTOs.WelcomeManager
{
    public class ReceptionDocumentWithAnimalOwnerInfo
    {
        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public AnimalChipOwner? AnimalChipOwner { get; set; } 
    }
}
