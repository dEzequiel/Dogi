using Application.Features.UserManager.Commands;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;

namespace Api.GraphQL.Mutations;

public class UserManagerMutations
{
    public ILogger<UserManagerMutations> Logger { get; set; } = null!;
    public IMediator Mediator { get; set; } = null!;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public UserManagerMutations(ILogger<UserManagerMutations> logger, IMediator mediator)
    {
        Logger = logger;
        Mediator = mediator;
    }

    public async Task<User> Register([Service] ISender Mediator, UserData credentials)
    {
        try
        {
            Logger.LogInformation("UserManagerMutations --> Register --> Start");

            var result = await Mediator.Send(new RegisterUserRequest(credentials));

            if (result.Data is null)
            {
                Logger.LogInformation("UserManagerMutations --> Register --> Error");

                throw new DogiException(result.Message);
            }
        
            Logger.LogInformation("UserManagerMutations --> Register --> End");

            return result.Data;
        }
        catch (DogiException ex)
        {
            Logger.LogInformation("UserManagerMutations --> Register --> Error");

            throw new DogiException(ex.Message);
        }
        catch (Exception ex)
        {
            Logger.LogInformation("UserManagerMutations --> Register --> Error");

            throw new DogiException(ex.Message);
        }
    }
}