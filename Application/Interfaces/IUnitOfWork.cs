
using Application.Interfaces.Repositories;

namespace Application.Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// ReceptionDocumentRepository
        /// </summary>
        IReceptionDocumentRepository ReceptionDocumentRepository { get; }
        IIndividualProceedingRepository IndividualProceedingRepository { get; }
        IAnimalChipRepository AnimalChipRepository { get; }
        IAnimalZoneRepository AnimalZoneRepository { get; }
        ICageRepository CageRepository { get; }
        IIndividualProceedingStatusRepository IndividualProceedingStatusRepository { get; }
        IAnimalCategoryRepository AnimalCategoryRepository { get; }
        ISexRepository SexRepository { get; }
        IMedicalRecordRepository MedicalRecordRepository { get; }
        IVaccinationCardRepository VaccinationCardRepository { get; }
        IVaccinationCardVaccineRepository VaccinationCardVaccineRepository { get; }
        IVaccineRepository VaccineRepository { get; }
        /// <summary>
        /// Complete method for transaction complete
        /// </summary>
        /// <returns>Return transaction status</returns>
        Task<int> CompleteAsync(CancellationToken ct = default);
    }
}
