

using Application.Service.Abstraction.Read;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.User.Commands;

/// <summary>
/// Register user request implementation.
/// </summary>
public class RegisterUserRequest : IRequest<ApiResponse<Domain.Entities.User>>
{
    public UserData UserData { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userData"></param>
    public RegisterUserRequest(UserData userData)
    {
        UserData = userData;
    }
}

/// <summary>
/// Register user request handler implementation.
/// </summary>
public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, ApiResponse<Domain.Entities.User>>
{
    private readonly ILogger<RegisterUserRequestHandler> Logger;
    private readonly IUserWriteService _userWriteService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userReadService"></param>
    public RegisterUserRequestHandler(ILogger<RegisterUserRequestHandler> logger, IUserWriteService userWriteService)
    {
        Logger = logger;
        _userWriteService = userWriteService;
    }

    ///<inheritdoc />
    public async Task<ApiResponse<Domain.Entities.User>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        Logger.LogInformation("RegisterUserRequestHandler --> AddAsync --> Start");
        
        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.UserData, nameof(request.UserData));
        Guard.Against.Null(request.UserData.Password, nameof(request.UserData.Password));
        Guard.Against.Null(request.UserData.Username, nameof(request.UserData.Username));

        var result = await _userWriteService.Register(request.UserData, cancellationToken);
        
        Logger.LogInformation("RegisterUserRequestHandler --> AddAsync --> End");

        return new ApiResponse<Domain.Entities.User>(result);
    }
}