using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Service.Abstraction.Write;

public interface IAdoptionPendingWriteService : IApplicationServiceBase
{
    /// <summary>
    /// Add new AdoptionPending.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<AdoptionPending> AddAsync(AdoptionPending entity, AdminData adminData, CancellationToken ct = default);

    Task<bool> CloseAdoptionAsync(Guid id, AdminData adminData, CancellationToken ct = default);
}