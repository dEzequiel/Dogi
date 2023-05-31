using Crosscuting.Api;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Managers.Abstraction;

public interface IUserManager : IApplicationServiceBase
{
    /// <summary>
    /// Register a new user generating token and hashish password.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<User> Register(UserData user, CancellationToken ct = default);
    
    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> Login(UserData user, CancellationToken ct = default);
}