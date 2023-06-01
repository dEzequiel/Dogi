namespace Application.DTOs.UserManager;

public class UserWithJsonWebToken
{
    public string Username { get; set; } = null!;
    public string Token { get; set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="token"></param>
    public UserWithJsonWebToken(string username, string token)
    {
        Username = username;
        Token = token;
    }
    /// <summary>
    /// Constructor.
    /// </summary>
    public UserWithJsonWebToken() { }
}