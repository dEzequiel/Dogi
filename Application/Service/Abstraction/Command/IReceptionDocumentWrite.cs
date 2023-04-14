using Application.DTOs.ReceptionDocument;
using Crosscuting.Base.Interfaces;

namespace Application.Service.Abstraction.Command
{
    /// <summary>
    /// ReceptionDocument write operations definition.
    /// </summary>
    public interface IReceptionDocumentWrite : IApplicationServiceBase
    {
        /// <summary>
        /// Add new ReceptionDocument.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ReceptionDocumentForGet> AddAsync(ReceptionDocumentForAdd entity, CancellationToken ct = default);

        /// <summary>
        /// Update existing ReceptionDocument.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ReceptionDocumentForGet?> UpdateAsync(ReceptionDocumentForUpdate entity, CancellationToken ct = default);

        /// <summary>
        /// Soft delete existing ReceptionDocument.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> LogicRemoveAsync(Guid id,  CancellationToken ct = default);
    }
}
