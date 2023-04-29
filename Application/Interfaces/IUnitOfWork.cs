
namespace Application.Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// ReceptionDocumentRepository
        /// </summary>
        IReceptionDocumentRepository ReceptionDocumentRepository { get; }

        /// <summary>
        /// Complete method for transaction complete
        /// </summary>
        /// <returns>Return transaction status</returns>
        Task<int> CompleteAsync(CancellationToken ct = default);
    }
}
