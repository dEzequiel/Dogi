using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.UserManager.Commands;

/// <summary>
/// User registration request implementation.
/// </summary>
public class RegisterUserRequest : IRequest<ApiResponse<Domain.Entities.User>>
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
public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, ApiResponse<Domain.Entities.User>>
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

    public async Task<ApiResponse<Domain.Entities.User>> Handle(RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("RegisterUserRequestHandler --> Handle --> Start");

        Guard.Against.Null(request, nameof(request));

        var result = await UserManager.Register(request.UserDataRegister, cancellationToken);

        Logger.LogInformation("RegisterUserRequestHandler --> Handle --> End");

        return new ApiResponse<Domain.Entities.User>(result);
    }
}