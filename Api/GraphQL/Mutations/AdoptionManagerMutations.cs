using System.Security.Claims;
using Application.DTOs.AdoptionManager;
using Application.Features.AdoptionManager.Commands;
using Crosscuting.Api;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using MediatR;

namespace Api.GraphQL.Mutations;

public class AdoptionManagerMutations
{
    private readonly ILogger<AdoptionManagerMutations> _logger;
    private readonly ClaimsPrincipal _claimsPrincipal;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="claimsPrincipal"></param>
    public AdoptionManagerMutations(ILogger<AdoptionManagerMutations> logger, ClaimsPrincipal claimsPrincipal)
    {
        _logger = logger;
        _claimsPrincipal = claimsPrincipal;
    }

    /// <summary>
    /// Apply to a pending adoption that is available. 
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="applicationInformation"></param>
    /// <param name="userData"></param>
    /// <returns></returns>
    /// <exception cref="DogiException"></exception>
    public async Task<AdoptionApplication> ApplyForAdoption([Service] ISender mediator,
        AdoptionApplicationInformation applicationInformation)
    {
        try
        {
            _logger.LogInformation("AdoptionManagerMutations --> ApplyForAdoption --> Start");

            var result = await mediator.Send(new ApplyForAdoptionRequest(
                applicationInformation.AdoptionPendingId, applicationInformation.AdoptionApplication, GetUserData()));

            _logger.LogInformation("AdoptionManagerMutations --> ApplyForAdoption --> End");

            return result.Data;
        }
        catch (DogiException ex)
        {
            _logger.LogInformation("AdoptionManagerMutations --> ApplyForAdoption --> Error");

            throw new DogiException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdoptionManagerMutations --> ApplyForAdoption --> Error");
            throw new DogiException(ex.Message);
        }
    }

    public async Task<AdoptionPending> CreateAdoptionPending([Service] ISender mediator,
        AdoptionPendingInformation adoptionPendingInformation)
    {
        try
        {
            _logger.LogInformation("AdoptionManagerMutations --> CreateAdoptionPending --> Start");

            var result = await mediator.Send(new RegisterAdoptionPendingRequest(
                adoptionPendingInformation.IndividualProceedingId, adoptionPendingInformation.AdoptionPendingData,
                GetAdminData()));

            _logger.LogInformation("AdoptionManagerMutations --> CreateAdoptionPending --> End");

            return result.Data;
        }
        catch (DogiException ex)
        {
            _logger.LogInformation("AdoptionManagerMutations --> CreateAdoptionPending --> Error");

            throw new DogiException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdoptionManagerMutations --> CreateAdoptionPending --> Error");
            throw new DogiException(ex.Message);
        }
    }

    public async Task<AdoptionApplication> CompleteAdoptionApplication([Service] ISender mediator,
        Guid adoptionApplicationId)
    {
        try
        {
            _logger.LogInformation("AdoptionManagerMutations --> CompleteAdoptionApplication --> Start");

            var result = await mediator.Send(new CompleteAdoptionRequest(
                adoptionApplicationId, GetAdminData()));

            _logger.LogInformation("AdoptionManagerMutations --> CompleteAdoptionApplication --> Start");

            return result.Data;
        }
        catch (DogiException ex)
        {
            _logger.LogInformation("AdoptionManagerMutations --> CompleteAdoptionApplication --> Error");

            throw new DogiException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdoptionManagerMutations --> CompleteAdoptionApplication --> Error");
            throw new DogiException(ex.Message);
        }
    }

    /// <summary>
    /// Get current user information.
    /// </summary>
    /// <returns>Object representing user information.</returns>
    private UserData GetUserData()
    {
        return new UserData
        {
            Id = Guid.Parse(_claimsPrincipal.FindFirstValue("Id")),
            Email = _claimsPrincipal.FindFirstValue("Email")
        };
    }

    /// <summary>
    /// Get current admin user information.
    /// </summary>
    /// <returns></returns>
    private AdminData GetAdminData()
    {
        return new AdminData()
        {
            Id = Guid.Parse(_claimsPrincipal.FindFirstValue("Id")),
            Email = _claimsPrincipal.FindFirstValue("Email")
        };
    }
}