using Domain.Entities.Shelter;

namespace Application.DTOs.UserManager;

public class UserWithCredentials
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
    public Person Person { get; set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="email"></param>
    /// <param name="token"></param>
    /// <param name="person"></param>
    public UserWithCredentials(Guid id, string email, string token, Person person)
    {
        Id = id;
        Email = email;
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