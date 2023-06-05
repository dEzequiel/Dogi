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
    Task<AdoptionPending> AddAsync(AdoptionPending entity, CancellationToken ct = default);
}