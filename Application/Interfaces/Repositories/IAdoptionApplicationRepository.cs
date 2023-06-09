using Application.Service.Interfaces;
using Crosscuting.Api;
using Crosscuting.Api.DTOs;
using Domain.Entities.Adoption;

namespace Application.Interfaces.Repositories;

public interface IAdoptionApplicationRepository : IRepository<AdoptionApplication>
{
    /// <summary>
    /// Add new Adoption application.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userData"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task AddAsync(AdoptionApplication entity, UserData userData, CancellationToken ct = default);

    /// <summary>
    /// Get Adoption application by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionApplication> GetAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Accept adoption application by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> AcceptApplication(Guid id, AdminData adminData, CancellationToken ct = default);

    /// <summary>
    /// Decline adoption application by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> DeclinesApplicationAsync(IEnumerable<Guid> id, CancellationToken ct = default);

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="adoptionPendingId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<AdoptionApplication>> GetAllByAdoptionPendingIdAsync(Guid adoptionPendingId,
        CancellationToken ct = default);
}