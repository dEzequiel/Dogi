using Domain.Entities;
using Crosscuting.Api.DTOs.Response;
using Crosscuting.Api.DTOs;

namespace Application.Service.Interfaces
{
    public interface IReceptionDocumentRepository : IRepository<ReceptionDocument>
    {
        /// <summary>
        /// Add new ReceptionDocument.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        Task AddAsync(ReceptionDocument entity, AdminData admin);

        /// <summary>
        /// Get all ReceptionDocuments with pagination properties.
        /// </summary>
        /// <param name="paginated"></param>
        /// <returns>Collection of ReceptionDocuments.</returns>
        Task<IEnumerable<ReceptionDocument>> GetAllAsync(CancellationToken ct = default);

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

        /// <summary>
        /// Mark ReceptionDocument as deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task LogicRemoveAsync(Guid id, AdminData admin);
    }
}
