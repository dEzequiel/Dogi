using Domain.Entities;
using Crosscuting.Api.DTOs.Response;

namespace Application.Service.Interfaces
{
    public interface IReceptionDocumentRepository : IRepository<ReceptionDocument>
    {
        /// <summary>
        /// Get all ReceptionDocuments with pagination properties.
        /// </summary>
        /// <param name="paginated"></param>
        /// <returns></returns>
        Task<IEnumerable<ReceptionDocument>> GetAllPaginatedAsync(PaginatedRequest paginated);
    }
}
