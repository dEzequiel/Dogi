namespace Application.DTOs.User;

public class UserWithToken
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Authenticated token.
    /// </summary>
    public string Token { get; set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="email"></param>
    /// <param name="token"></param>
    public UserWithToken(Guid id, string email, string token)
    {
        Id = id;
        Email = email;
        Token = token;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserWithToken()
    {
    }
}