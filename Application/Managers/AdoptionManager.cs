using Application.Features.AdoptionApplication.Commands;
using Application.Interfaces;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Domain.Entities.Adoption;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers;

public class AdoptionManager : IAdoptionManager
{
    private readonly ILogger<AdoptionManager> Logger;
    private readonly IMediator Mediator;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionManager(ILogger<AdoptionManager> logger, IMediator mediator, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        Mediator = mediator;
        UnitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionApplication> RegisterAdoptionApplication(Guid adoptionPendingId,
        AdoptionApplication application, UserData userData)
    {
        application.AdoptionPendingId = adoptionPendingId;
        application.UserId = userData.Id;

        var adoptionApplicationRequest =
            await Mediator.Send(new InsertAdoptionApplicationRequest(application, userData));

        Guard.Against.Null(adoptionApplicationRequest.Data);
        return adoptionApplicationRequest.Data;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}