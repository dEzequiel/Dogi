using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Authentication;
using MediatR;
using Microsoft.Extensions.Logging;

public class AuthenticateUserRequest : IRequest<string>
{
    public UserDataLogin UserDataLogin { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userDataLogin"></param>
    public AuthenticateUserRequest(UserDataLogin userDataLogin)
    {
        UserDataLogin = userDataLogin;
    }
}

/// <summary>
/// Login user request handler implementation
/// </summary>
public class AuthenticateUserRequestHandler : IRequestHandler<AuthenticateUserRequest, string>
{
    private readonly ILogger<AuthenticateUserRequestHandler> Logger;
    private readonly IUserReadService _userReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userReadService"></param>
    public AuthenticateUserRequestHandler(ILogger<AuthenticateUserRequestHandler> logger,
        IUserReadService userReadService)
    {
        Logger = logger;
        _userReadService = userReadService;
    }

    ///<inheritdoc />
    public async Task<string> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("LoginUserRequestHandler --> AddAsync --> Start");

        Guard.Against.Null(request, nameof(request));

        var result = await _userReadService.Authenticate(request.UserDataLogin, cancellationToken);

        Logger.LogInformation("LoginUserRequestHandler --> AddAsync --> End");

        return result;
    }
}