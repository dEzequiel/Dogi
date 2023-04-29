using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction
{
    /// <summary>
    /// ReceptionDocument Write Service Definition.
    /// </summary>
    public interface IReceptionDocumentWrite : IApplicationServiceBase
    {
        /// <summary>
        /// Add new ReceptionDocument.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ReceptionDocument> AddAsync(ReceptionDocument entity, AdminData admin);

        /// <summary>
        /// Update existing ReceptionDocument.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ReceptionDocument?> UpdateAsync(ReceptionDocument entity);

        /// <summary>
        /// Soft delete existing ReceptionDocument.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> LogicRemoveAsync(Guid id, AdminData admin);
    }
}
