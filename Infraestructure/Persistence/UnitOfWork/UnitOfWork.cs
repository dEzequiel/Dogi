using Domain.Interfaces.Repositories;
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="workFlowAgent"></param>
        /// <param name="configuration"></param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Complete database transactions.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
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
