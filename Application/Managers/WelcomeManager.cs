using Application.DTOs.WelcomeManager;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Write;
using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Managers
{
    public class WelcomeManager 
    {
        private IReceptionDocumentWrite _receptionDocumentWrite;
        private IAnimalChipWrite _animalChipWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="animalChipOwnerWrite"></param>
        /// <param name="receptionDocumentWrite"></param>
        public WelcomeManager(IReceptionDocumentWrite receptionDocumentWrite, IAnimalChipWrite animalChipWrite)
        {
            _receptionDocumentWrite = receptionDocumentWrite;
            _animalChipWrite = animalChipWrite;
        }

        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition you take one way or the other.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="adminData"></param>
        /// <returns>An object where the information of the reception document and the information of the chip can be consulted together with that of the owner.</returns>
        public async Task<ReceptionDocumentWithAnimalOwnerInfo> AddAnimalWithOwnerInfo(ReceptionDocumentWithAnimalOwnerInfo data, AdminData adminData)
        {
            if(!data.ReceptionDocument.HasChip)
            {
                var entity = await _receptionDocumentWrite.AddAsync(data.ReceptionDocument, adminData);

                return new ReceptionDocumentWithAnimalOwnerInfo()
                {
                    ReceptionDocument = entity,
                    AnimalChip = null,
                };

            } else
            {
                var receptionDocumententity = await _receptionDocumentWrite.AddAsync(data.ReceptionDocument, adminData);

                var animalChipEntity = await _animalChipWrite.AddAsync(data.AnimalChip, adminData);

                return new ReceptionDocumentWithAnimalOwnerInfo()
                {
                    ReceptionDocument = receptionDocumententity,
                    AnimalChip = animalChipEntity,
                };
            }
        }
    }
}
