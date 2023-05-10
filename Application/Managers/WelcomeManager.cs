using Application.DTOs.WelcomeManager;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Managers
{
    public class WelcomeManager 
    {
        private IAnimalChipOwnerWrite _animalChipOwnerWrite;
        private IReceptionDocumentWrite _receptionDocumentWrite;


        public WelcomeManager() { }

        public WelcomeManager(IAnimalChipOwnerWrite animalChipOwnerWrite, IReceptionDocumentWrite receptionDocumentWrite)
        {
            _animalChipOwnerWrite = animalChipOwnerWrite;
            _receptionDocumentWrite = receptionDocumentWrite;
        }

        public async Task<ReceptionDocumentWithAnimalOwnerInfo> AddAnimalWithOwnerInfo(ReceptionDocument receptionDocument, AnimalChipOwner animalChipOwner, AdminData AdminData)
        {
            if(receptionDocument.HasChip.HasValue)
            {
                var entity = await _receptionDocumentWrite.AddAsync(receptionDocument, AdminData);

                return new ReceptionDocumentWithAnimalOwnerInfo()
                {
                    ReceptionDocument = entity,
                    AnimalChipOwner = null
                };

            } else
            {
                var receptionDocumententity = await _receptionDocumentWrite.AddAsync(receptionDocument, AdminData);
                var animalChipOwnerEntity = await  _animalChipOwnerWrite.AddAsync(animalChipOwner, AdminData);

                return new ReceptionDocumentWithAnimalOwnerInfo()
                {
                    ReceptionDocument = receptionDocumententity,
                    AnimalChipOwner = animalChipOwnerEntity
                };
            }
        }
    }
}
