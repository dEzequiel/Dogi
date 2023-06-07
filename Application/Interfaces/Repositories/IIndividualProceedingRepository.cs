using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities.Shelter;
using Domain.Enums.Shelter;

namespace Application.Interfaces.Repositories
{
    public interface IIndividualProceedingRepository : IRepository<IndividualProceeding>
    {
        /// <summary>
        /// Add new IndividualProceeding.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(IndividualProceeding entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Get all IndividualProceedings.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<IndividualProceeding>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all IndividualProceedings filtered by status.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<IndividualProceeding>> GetAllFilterByStatusAsync(int status,
            CancellationToken ct = default);

        /// <summary>
        /// Mark IndividualProceeding as deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing IndividualProceeding.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, IndividualProceedingStatuses entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update individual proceeding status to adopt.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceeding> AdoptAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Close Individual proceesing.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceeding> CloseAsync(Guid id, AdminData adminData, CancellationToken ct = default);
    }
}