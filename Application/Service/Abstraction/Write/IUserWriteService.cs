using Crosscuting.Api;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Write;

public interface IUserWriteService : IApplicationServiceBase
{
    /// <summary>
    /// Add new User.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<User> AddAsync(UserData entity, CancellationToken ct = default);

    /// <summary>
    /// Login.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> LoginAsync(UserData entity, CancellationToken ct = default);
}