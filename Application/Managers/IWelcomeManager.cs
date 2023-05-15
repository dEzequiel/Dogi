using Application.DTOs.WelcomeManager;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;

namespace Application.Managers
{
    public interface IWelcomeManager : IApplicationServiceBase
    {
        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="adminData"></param>
        /// <returns>Information about register. Includ ReceptionDocument, AnimalChip, Person and IndividualProceeding if process.</returns>
        Task<RegisterInformation> AddAnimalWithOwnerInfo(ReceptionDocumentWithAnimalInformation data, AdminData adminData);
    }
}