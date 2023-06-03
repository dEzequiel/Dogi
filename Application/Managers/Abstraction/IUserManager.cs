using Application.DTOs.UserManager;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Authentication;
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
    Task<string> Authenticate(UserDataLogin user, CancellationToken ct = default);

    /// <summary>
    /// Assigne role to user.
    /// </summary>
    /// <param name="roleUser"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<UserWithPermissions> AssigneRole(UserWithRoles userRoles, CancellationToken ct = default);
}