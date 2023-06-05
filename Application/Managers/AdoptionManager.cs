using Application.Features.AdoptionApplication.Commands;
using Application.Features.AdoptionPending.Commands;
using Application.Interfaces;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Domain.Entities.Adoption;
using Domain.Enums.Adoption;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers;

public class AdoptionManager : IAdoptionManager
{
    private readonly ILogger<AdoptionManager> _logger;
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionManager(ILogger<AdoptionManager> logger, IMediator mediator, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionApplication> RegisterAdoptionApplication(Guid adoptionPendingId,
        AdoptionApplication application, UserData userData)
    {
        application.AdoptionPendingId = adoptionPendingId;
        application.AdoptionApplicationStatusId = (int)AdoptionApplicationStatuses.Waiting;
        application.UserId = userData.Id;

        var adoptionApplicationRequest =
            await _mediator.Send(new InsertAdoptionApplicationRequest(application, userData));

        Guard.Against.Null(adoptionApplicationRequest.Data);
        return adoptionApplicationRequest.Data;
    }

    ///<inheritdoc />
    public async Task<AdoptionPending> RegisterAdoptionPending(Guid individualProceedingId,
        AdoptionPending adoptionInformation)
    {
        adoptionInformation.IndividualProceedingId = individualProceedingId;
        adoptionInformation.AdoptionPendingStatusId = (int)AdoptionPendingStatuses.Open;

        var adoptionPendingRequest =
            await _mediator.Send(new InsertAdoptionPendingRequest(adoptionInformation));

        Guard.Against.Null(adoptionPendingRequest.Data);
        return adoptionPendingRequest.Data;
    }


    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}