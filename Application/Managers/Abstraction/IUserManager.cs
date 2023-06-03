using Application.DTOs.UserManager;
using Crosscuting.Api;
using Crosscuting.Base.Interfaces;

namespace Application.Managers.Abstraction;

public interface IUserManager : IApplicationServiceBase
{
    /// <summary>
    /// Register a new user generating token and hashish password.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<RegisteredUserWithPersonCredentials> Register(UserDataRegister user, CancellationToken ct = default);

    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<string> Authenticate(UserDataRegister user, CancellationToken ct = default);
}