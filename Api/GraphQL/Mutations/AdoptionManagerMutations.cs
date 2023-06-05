using Application.DTOs.AdoptionManager;
using Application.Features.AdoptionManager.Commands;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Domain.Entities.Authorization;
using MediatR;

namespace Api.GraphQL.Mutations;

public class AdoptionManagerMutations
{
    private readonly ILogger<AdoptionManagerMutations> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    public AdoptionManagerMutations(ILogger<AdoptionManagerMutations> logger)
    {
        _logger = logger;
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
        [Service] IHttpContextAccessor? httpContextAccessor, AdoptionApplicationInformation applicationInformation)
    {
        try
        {
            _logger.LogInformation("AdoptionManagerMutations --> ApplyForAdoption --> Start");

            var result = await mediator.Send(new ApplyForAdoptionRequest(
                applicationInformation.AdoptionPendingId, applicationInformation.AdoptionApplication,
                GetUserData(httpContextAccessor)));

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

    /// <summary>
    /// Get current user information.
    /// </summary>
    /// <returns>Object representing user information.</returns>
    private UserData GetUserData(IHttpContextAccessor context)
    {
        var user = (User)context.HttpContext.Items["User"];
        return new UserData()
        {
            Id = Guid.Parse(user.Id.ToString()),
            Email = user.Email
        };
    }
}