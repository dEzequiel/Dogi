using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities.Adoption;

namespace Application.Interfaces.Repositories;

public interface IAdoptionPendingRepository : IRepository<AdoptionPending>
{
    /// <summary>
    /// Get AdoptionPending by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionPending> GetAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Add new adoption pending.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task AddAsync(AdoptionPending entity, AdminData adminData, CancellationToken ct = default);

    /// <summary>
    /// Close adoption pending.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="adminData"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> CloseAsync(Guid id, AdminData adminData, CancellationToken ct = default);

    /// <summary>
    /// Get all adoption pendings filter by status.
    /// </summary>
    /// <param name="status"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<AdoptionPending>> GetAllByStatus(int status, CancellationToken ct = default);
}