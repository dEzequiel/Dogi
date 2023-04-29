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
        Task AddAsync(ReceptionDocument entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Get all ReceptionDocuments.
        /// </summary>
        /// <param name="paginated"></param>
        /// <returns>Collection of ReceptionDocuments.</returns>
        Task<IEnumerable<ReceptionDocument>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all ReceptionDocuments filtered by chip possesion.
        /// </summary>
        /// <param name="hasChip"></param>
        /// <returns></returns>
        Task<IEnumerable<ReceptionDocument>> GetAllFilterByChipPossessionAsync(bool? hasChip, CancellationToken ct = default);

        /// <summary>
        /// Mark ReceptionDocument as deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default);
    }
}
