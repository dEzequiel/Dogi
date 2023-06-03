using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Authentication;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.UserManager.Commands;

/// <summary>
/// User login request implementation.
/// </summary>
public class LoginUserRequest : IRequest<string>
{
    public UserDataLogin UserDataLogin { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userDataLogin"></param>
    public LoginUserRequest(UserDataLogin userDataLogin)
    {
        UserDataLogin = userDataLogin;
    }
}

/// <summary>
/// User login request handler implementation.
/// </summary>
public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, string>
{
    private readonly ILogger<LoginUserRequestHandler> Logger;
    private readonly IUserManager UserManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userManager"></param>
    public LoginUserRequestHandler(ILogger<LoginUserRequestHandler> logger, IUserManager userManager)
    {
        Logger = logger;
        UserManager = userManager;
    }

    ///<inheritdoc />
    public async Task<string> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("LoginUserRequestHandler --> Handle --> Start");

        Guard.Against.Null(request, nameof(request));

        var result = await UserManager.Authenticate(request.UserDataLogin, cancellationToken);

        Logger.LogInformation("LoginUserRequestHandler --> Handle --> End");

        return result;
    }
}