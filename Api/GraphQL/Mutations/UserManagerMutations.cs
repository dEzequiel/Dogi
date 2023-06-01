using Application.DTOs.UserManager;
using Application.Features.UserManager.Commands;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Api.GraphQL.Mutations;

[AllowAnonymous]
public class UserManagerMutations
{
    private readonly IMediator Mediator;
    private readonly ILogger<UserManagerMutations> Logger;
    
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
    
    public async Task<UserWithJsonWebToken> Authenticate([Service] ISender Mediator, UserData credentials)
    {
        try
        {
            Logger.LogInformation("UserManagerMutations --> Login --> Start");

            var result = await Mediator.Send(new AuthenticateUserRequest(credentials));

            return new UserWithJsonWebToken()
            {
                Username = credentials.Username,
                Token = result
            };
        }
        catch (DogiException ex)
        {
            Logger.LogInformation("UserManagerMutations --> Login --> Error");

            throw new DogiException(ex.Message);
        }
        catch (Exception ex)
        {
            Logger.LogInformation("UserManagerMutations --> Login --> Error");

            throw new DogiException(ex.Message);
        }
    }
}