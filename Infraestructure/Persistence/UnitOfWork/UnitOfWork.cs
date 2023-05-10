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
        public IIndividualProceedingRepository IndividualProceedingRepository => new IndividualProceedingRepository(_context);
        public IAnimalChipOwnerRepository AnimalChipOwnerRepository => new AnimalChipOwnerRepository(_context);

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
