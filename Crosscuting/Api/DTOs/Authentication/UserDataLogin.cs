namespace Crosscuting.Api.DTOs.Authentication;

/// <summary>
/// Represents user login credentils.
/// </summary>
public class UserDataLogin
{
    /// <summary>
    /// Email credential.
    /// </summary>
    public string Email { get; set; } = null!;
    /// <summary>
    /// Password credential.
    /// </summary>
    public string Password { get; set; } = null!;
}