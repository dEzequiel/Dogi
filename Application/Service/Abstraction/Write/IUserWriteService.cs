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
    Task<User> Register(UserDataRegister entity, CancellationToken ct = default);
}