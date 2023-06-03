using Application.DTOs.UserManager;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// User registration request implementation.
/// </summary>
public class RegisterUserWithPersonRequest : IRequest<ApiResponse<RegisteredUserWithPersonCredentials>>
{
    public UserDataRegister UserDataRegister { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userData"></param>
    public RegisterUserWithPersonRequest(UserDataRegister userDataRegister)
    {
        UserDataRegister = userDataRegister;
    }
}

/// <summary>
/// User registration request handler implementation.
/// </summary>
public class RegisterUserRequestHandler : IRequestHandler<RegisterUserWithPersonRequest,
    ApiResponse<RegisteredUserWithPersonCredentials>>
{
    private readonly ILogger<RegisterUserRequestHandler> Logger;
    private readonly IUserManager UserManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userManager"></param>
    public RegisterUserRequestHandler(ILogger<RegisterUserRequestHandler> logger, IUserManager userManager)
    {
        Logger = logger;
        UserManager = userManager;
    }

    public async Task<ApiResponse<RegisteredUserWithPersonCredentials>> Handle(
        RegisterUserWithPersonRequest withPersonRequest,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("RegisterUserRequestHandler --> Handle --> Start");

        Guard.Against.Null(withPersonRequest, nameof(withPersonRequest));

        var result = await UserManager.Register(withPersonRequest.UserDataRegister, cancellationToken);

        Logger.LogInformation("RegisterUserRequestHandler --> Handle --> End");

        return new ApiResponse<RegisteredUserWithPersonCredentials>(result);
    }
}