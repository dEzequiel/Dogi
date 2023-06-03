using Application.DTOs.UserManager;
using Application.Features.UserManager.Commands;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
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

    public async Task<RegisteredUserWithPersonCredentials> Register([Service] ISender Mediator,
        UserDataRegister credentials)
    {
        try
        {
            Logger.LogInformation("UserManagerMutations --> Register --> Start");

            var result = await Mediator.Send(new RegisterUserWithPersonRequest(credentials));

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

    public async Task<UserWithJsonWebToken> Authenticate([Service] ISender Mediator, UserDataRegister credentials)
    {
        try
        {
            Logger.LogInformation("UserManagerMutations --> Login --> Start");

            var result = await Mediator.Send(new AuthenticateUserRequest(credentials));

            return new UserWithJsonWebToken()
            {
                Username = credentials.Email,
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

    public async Task<UserWithPermissions> AssigneRole([Service] ISender Mediator, UserWithRoles userWithRoles)
    {
        try
        {
            Logger.LogInformation("UserManagerMutations --> AssigneRole --> Error");

            var result = await Mediator.Send(new AssigneUserRoleRequest(userWithRoles));

            return result.Data;
        }
        catch (DogiException ex)
        {
            Logger.LogInformation("UserManagerMutations --> AssigneRole --> Error");

            throw new DogiException(ex.Message);
        }
    }
}