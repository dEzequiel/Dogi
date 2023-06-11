using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Authentication;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.User.Commands;

/// <summary>
/// Register user request implementation.
/// </summary>
public class RegisterUserRequest : IRequest<ApiResponse<Domain.Entities.Authorization.User>>
{
    public UserDataRegister UserDataRegister { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userDataRegister"></param>
    public RegisterUserRequest(UserDataRegister userDataRegister)
    {
        UserDataRegister = userDataRegister;
    }
}

/// <summary>
/// Register user request handler implementation.
/// </summary>
public class
    RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, ApiResponse<Domain.Entities.Authorization.User>>
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
    public async Task<ApiResponse<Domain.Entities.Authorization.User>> Handle(RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        Logger.LogInformation("RegisterUserRequestHandler --> AddAsync --> Start");

        Guard.Against.Null(request, nameof(request));
        Guard.Against.Null(request.UserDataRegister, nameof(request.UserDataRegister));
        Guard.Against.Null(request.UserDataRegister.Password, nameof(request.UserDataRegister.Password));
        Guard.Against.Null(request.UserDataRegister.Email, nameof(request.UserDataRegister.Email));

        var result = await _userWriteService.Register(request.UserDataRegister, cancellationToken);

        Logger.LogInformation("RegisterUserRequestHandler --> AddAsync --> End");

        return new ApiResponse<Domain.Entities.Authorization.User>(result);
    }
}