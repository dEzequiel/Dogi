using Application.DTOs.WelcomeManager;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Managers
{
    public class WelcomeManager 
    {
        private IAnimalChipOwnerWrite _animalChipOwnerWrite;
        private IReceptionDocumentWrite _receptionDocumentWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="animalChipOwnerWrite"></param>
        /// <param name="receptionDocumentWrite"></param>
        public WelcomeManager(IAnimalChipOwnerWrite animalChipOwnerWrite, IReceptionDocumentWrite receptionDocumentWrite)
        {
            _animalChipOwnerWrite = animalChipOwnerWrite;
            _receptionDocumentWrite = receptionDocumentWrite;
        }

        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition you take one way or the other.
        /// </summary>
        /// <param name="receptionDocument"></param>
        /// <param name="animalChipOwner"></param>
        /// <param name="adminData"></param>
        /// <returns>An object where the information of the reception document and the information of the chip can be consulted together with that of the owner.</returns>
        public async Task<ReceptionDocumentWithAnimalOwnerInfo> AddAnimalWithOwnerInfo(ReceptionDocument receptionDocument, AnimalChipOwner animalChipOwner, AdminData adminData)
        {
            if(!receptionDocument.HasChip.Value)
            {
                var entity = await _receptionDocumentWrite.AddAsync(receptionDocument, adminData);

                return new ReceptionDocumentWithAnimalOwnerInfo()
                {
                    ReceptionDocument = entity,
                    AnimalChipOwner = null
                };

            } else
            {
                var receptionDocumententity = await _receptionDocumentWrite.AddAsync(receptionDocument, adminData);
                var animalChipOwnerEntity = await  _animalChipOwnerWrite.AddAsync(animalChipOwner, adminData);

                return new ReceptionDocumentWithAnimalOwnerInfo()
                {
                    ReceptionDocument = receptionDocumententity,
                    AnimalChipOwner = animalChipOwnerEntity
                };
            }
        }
    }
}
