using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.User.Commands;

/// <summary>
/// Login user request implementation.
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
/// Login user request handler implementation
/// </summary>
public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, ApiResponse<bool>>
{
    private readonly ILogger<LoginUserRequestHandler> Logger;
    private readonly IUserWriteService UserWriteService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userWriteService"></param>
    public LoginUserRequestHandler(ILogger<LoginUserRequestHandler> logger, IUserWriteService userWriteService)
    {
        Logger = logger;
        UserWriteService = userWriteService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<bool>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("LoginUserRequestHandler --> AddAsync --> Start");
        
        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.UserData, nameof(request.UserData));
        Guard.Against.Null(request.UserData.Password, nameof(request.UserData.Password));
        Guard.Against.Null(request.UserData.Username, nameof(request.UserData.Username));

        var result = await UserWriteService.LoginAsync(request.UserData, cancellationToken);
        
        Logger.LogInformation("LoginUserRequestHandler --> AddAsync --> End");

        return new ApiResponse<bool>(result);
    }
}
