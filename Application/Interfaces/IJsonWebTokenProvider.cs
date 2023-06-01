using Crosscuting.Api;
using Domain.Entities;

namespace Application.Service.Interfaces;

public interface IJsonWebTokenProvider
{
    /// <summary>
    /// Generate json web token.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    string Generate(User user);
}