using Crosscuting.Api;
using Crosscuting.Api.DTOs;
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
    Task<AdoptionApplication> RegisterAdoptionApplication(Guid adoptionPendingId, AdoptionApplication application,
        UserData userData);

    /// <summary>
    /// Register new Adoption pending.
    /// </summary>
    /// <param name="individualProceedingId"></param>
    /// <param name="adoptionInformation"></param>
    /// <returns></returns>
    Task<AdoptionPending> RegisterAdoptionPending(Guid individualProceedingId, AdminData adminData,
        AdoptionPending adoptionInformation);

    /// <summary>
    /// Complete Adoption application.
    /// </summary>
    /// <param name="adoptionApplicationId"></param>
    /// <param name="adminData"></param>
    /// <returns></returns>
    Task<AdoptionApplication> CompleteAdoptionApplication(Guid adoptionApplicationId, bool pickedUp,
        AdminData adminData);
}