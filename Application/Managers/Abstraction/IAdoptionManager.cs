using Crosscuting.Api;
using Crosscuting.Base.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Managers.Abstraction;

public interface IAdoptionManager : IApplicationServiceBase
{
    /// <summary>
    /// Register new Adoption application.
    /// </summary>
    /// <param name="adoptionPendingId"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    Task RegisterAdoptionApplication(Guid adoptionPendingId, AdoptionApplication application, UserData userData);
}