using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities.Authorization;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// User registration request implementation.
/// </summary>
public class RegisterUserRequest : IRequest<ApiResponse<User>>
{
    public UserDataRegister UserDataRegister { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userData"></param>
    public RegisterUserRequest(UserDataRegister userDataRegister)
    {
        UserDataRegister = userDataRegister;
    }
}

/// <summary>
/// User registration request handler implementation.
/// </summary>
public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, ApiResponse<User>>
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

    public async Task<ApiResponse<User>> Handle(RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("RegisterUserRequestHandler --> Handle --> Start");

        Guard.Against.Null(request, nameof(request));

        var result = await UserManager.Register(request.UserDataRegister, cancellationToken);

        Logger.LogInformation("RegisterUserRequestHandler --> Handle --> End");

        return new ApiResponse<User>(result);
    }
}