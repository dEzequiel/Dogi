using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.UserManager.Commands;

/// <summary>
/// User login request implementation.
/// </summary>
public class LoginUserRequest : IRequest<ApiResponse<bool>>
{
    public UserData UserData { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userData"></param>
    public LoginUserRequest(UserData userData)
    {
        UserData = userData;
    }
}

/// <summary>
/// User login request handler implementation.
/// </summary>
public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, ApiResponse<bool>>
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
    public async Task<ApiResponse<bool>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("LoginUserRequestHandler --> Handle --> Start");
        
        Guard.Against.Null(request, nameof(request));

        var result = await UserManager.Login(request.UserData, cancellationToken);
        
        Logger.LogInformation("LoginUserRequestHandler --> Handle --> End");

        return new ApiResponse<bool>(result);
    }
}