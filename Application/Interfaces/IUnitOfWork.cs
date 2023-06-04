using Application.Interfaces.Repositories;
using Application.Service.Interfaces;

namespace Application.Interfaces
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
        IVaccineStatusRepository VaccineStatusRepository { get; }
        IPersonRepository PersonRepository { get; }
        IPersonBannedInformationRepository PersonBannedInformationRepository { get; }
        IMedicalRecordStatusRepository MedicalRecordStatusRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleUserRepository RoleUserRepository { get; }
        IRolePermissionRepository RolePermissionRepository { get; }
        IRoleRepository RoleRepository { get; }
        IAdoptionApplicationRepository AdoptionApplicationRepository { get; }

        /// <summary>
        /// Complete method for transaction complete
        /// </summary>
        /// <returns>Return transaction status</returns>
        Task<int> CompleteAsync(CancellationToken ct = default);
    }
}