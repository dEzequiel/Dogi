using Crosscuting.Api;
using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Service.Abstraction.Write;

public interface IAdoptionApplicationWriteService : IApplicationServiceBase
{
    /// <summary>
    /// Register new adoption application.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userData"></param>
    /// <returns></returns>
    Task<AdoptionApplication> AddAsync(AdoptionApplication entity, UserData userData);
}