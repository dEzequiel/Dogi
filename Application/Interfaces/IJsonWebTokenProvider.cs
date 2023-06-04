using Domain.Entities.Authorization;

namespace Application.Interfaces;

public interface IJsonWebTokenProvider
{
    /// <summary>
    /// Generate json web token.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<string> Generate(User user);
}