using Application.Features.AdoptionApplication.Commands;
using Application.Features.AdoptionApplication.Queries;
using Application.Features.AdoptionPending.Commands;
using Application.Features.Cage.Commands;
using Application.Features.IndividualPro.Commands;
using Application.Interfaces;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities.Adoption;
using Domain.Entities.Shelter;
using Domain.Enums.Adoption;
using Domain.Enums.Shelter;
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
        AdminData adminData, AdoptionPending adoptionInformation)
    {
        adoptionInformation.IndividualProceedingId = individualProceedingId;
        adoptionInformation.AdoptionPendingStatusId = (int)AdoptionPendingStatuses.Open;

        var adoptionPendingRequest =
            await _mediator.Send(new InsertAdoptionPendingRequest(adoptionInformation, adminData));

        Guard.Against.Null(adoptionPendingRequest.Data);
        return adoptionPendingRequest.Data;
    }

    public async Task<AdoptionApplication> CompleteAdoptionApplication(Guid adoptionApplicationId, bool pickedUp,
        AdminData adminData)
    {
        await _mediator.Send(new CompleteAdoptionApplicationRequest(adoptionApplicationId, adminData));

        var adoptionApplicationRequest =
            await _mediator.Send(new GetAdoptionApplicationByIdRequest(adoptionApplicationId));

        Guard.Against.Null(adoptionApplicationRequest.Data, nameof(adoptionApplicationRequest.Data));
        await _mediator.Send(new CloseAdoptionPendingRequest(adoptionApplicationRequest.Data.AdoptionPendingId,
            adminData));

        var individualProceeding = adoptionApplicationRequest.Data.AdoptionPending.IndividualProceeding;
        await AdoptIndividualProceedingAndMoveCageZone(individualProceeding.Id, pickedUp, adminData);

        Guard.Against.Null(adoptionApplicationRequest.Data);
        return adoptionApplicationRequest.Data;
    }

    private async Task AdoptIndividualProceedingAndMoveCageZone(Guid individiualProceedingId, bool pickedUp,
        AdminData adminData)
    {
        ApiResponse<IndividualProceeding> individualProceedingRequest = null;
        if (pickedUp is false)
        {
            individualProceedingRequest =
                await _mediator.Send(new AdoptIndividualProceedingRequest(individiualProceedingId, adminData));
            await _mediator.Send(new MoveCageAnimalZoneRequest(individualProceedingRequest.Data.CageId.Value,
                (int)AnimalZones.WaitingForOwner, adminData));
            return;
        }

        individualProceedingRequest =
            await _mediator.Send(new CloseIndividualProceedingRequest(individiualProceedingId, adminData));
    }

    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}