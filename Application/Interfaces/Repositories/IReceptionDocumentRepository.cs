using Application.DTOs.ReceptionDocument;
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
        /// <returns>Collection of ReceptionDocuments.</returns>
        Task<IEnumerable<ReceptionDocument>> GetAllPaginatedAsync(PaginatedRequest paginated);

        /// <summary>
        /// Get all ReceptionDocuments with pagination properties filter by chip possesion.
        /// </summary>
        /// <param name="hasChip"></param>
        /// <returns></returns>
        Task<IEnumerable<ReceptionDocument>> GetAllPaginatedFilterByChipPossessionAsync(PaginatedRequest paginated, 
            bool hasChip);

        /// <summary>
        /// Get total count of ReceptionDocuments.
        /// </summary>
        /// <returns>Number representing the total count of ReceptionDocuments.</returns>
        Task<int> GetAllCountAsync();
    }
}
