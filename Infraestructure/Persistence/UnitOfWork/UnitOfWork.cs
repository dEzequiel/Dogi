using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Service.Interfaces;
using Infraestructure.Context;
using Infraestructure.Persistence.Repositories;

namespace Infraestructure.Persistence.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Repositories under unit of work.
        /// </summary>
        public IReceptionDocumentRepository ReceptionDocumentRepository => new ReceptionDocumentRepository(_context);

        public IIndividualProceedingRepository IndividualProceedingRepository =>
            new IndividualProceedingRepository(_context);

        public IAnimalChipRepository AnimalChipRepository => new AnimalChipRepository(_context);
        public IAnimalZoneRepository AnimalZoneRepository => new AnimalZoneRepository(_context);
        public ICageRepository CageRepository => new CageRepository(_context);

        public IIndividualProceedingStatusRepository IndividualProceedingStatusRepository =>
            new IndividualProceedingStatusRepository(_context);

        public IAnimalCategoryRepository AnimalCategoryRepository => new AnimalCategoryRepository(_context);
        public ISexRepository SexRepository => new SexRepository(_context);
        public IMedicalRecordRepository MedicalRecordRepository => new MedicalRecordRepository(_context);
        public IVaccinationCardRepository VaccinationCardRepository => new VaccinationCardRepository(_context);

        public IVaccinationCardVaccineRepository VaccinationCardVaccineRepository =>
            new VaccinationCardVaccineRepository(_context);

        public IVaccineRepository VaccineRepository => new VaccineRepository(_context);
        public IVaccineStatusRepository VaccineStatusRepository => new VaccineStatusRepository(_context);
        public IPersonRepository PersonRepository => new PersonRepository(_context);

        public IPersonBannedInformationRepository PersonBannedInformationRepository =>
            new PersonBannedInformationRepository(_context);

        public IMedicalRecordStatusRepository MedicalRecordStatusRepository =>
            new MedicalRecordStatusRepository(_context);

        public IUserRepository UserRepository => new UserRepository(_context);
        public IRoleUserRepository RoleUserRepository => new RoleUserRepository(_context);
        public IRolePermissionRepository RolePermissionRepository => new RolePermissionRepository(_context);
        public IRoleRepository RoleRepository => new RoleRepository(_context);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Complete database transactions.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// IDisposable is important because it’s possible for an object 
        /// to consume very little memory and yet tie up some expensive resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}