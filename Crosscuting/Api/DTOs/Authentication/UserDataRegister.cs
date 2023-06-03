using Domain.Entities.Shelter;

namespace Crosscuting.Api;

/// <summary>
/// Represents user register data.
/// </summary>
public class UserDataRegister
{
    /// <summary>
    /// Username
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = null!;

    public Person Person { get; set; } = null!;
}