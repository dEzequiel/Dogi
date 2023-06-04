using Domain.Entities.Shelter;

namespace Application.DTOs.UserManager;

public class UserWithCredentials
{
    public string Username { get; set; } = null!;
    public string Token { get; set; } = null!;
    public Person Person { get; set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="token"></param>
    /// <param name="person"></param>
    public UserWithCredentials(string username, string token, Person person)
    {
        Username = username;
        Token = token;
        Person = person;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserWithCredentials()
    {
    }
}