using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;
using Domain.Enums.Shelter;

namespace Application.Service.Abstraction.Write
{
    /// <summary>
    /// IndividualProceeding Write Service Definition.
    /// </summary>
    public interface IIndividualProceedingWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add new IndividualProceeding.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceeding> AddAsync(IndividualProceeding entity, AdminData admin,
            CancellationToken ct = default);

        /// <summary>
        /// Soft delete existing IndividualProceeding.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing IndividualProceeding status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceeding> UpdateAsync(Guid id, IndividualProceedingStatuses status, AdminData admin,
            CancellationToken ct = default);

        /// <summary>
        /// Update IndividualProceeding status to adopt.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceeding> AdoptAsync(Guid id, AdminData adminData, CancellationToken ct = default);
    }
}