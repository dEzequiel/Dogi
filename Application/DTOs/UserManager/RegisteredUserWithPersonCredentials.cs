using Domain.Entities.Shelter;

namespace Application.DTOs.UserManager;

public class RegisteredUserWithPersonCredentials
{
    public string Email { get; set; } = null!;

    public Person Person { get; set; } = null!;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="email"></param>
    /// <param name="person"></param>
    public RegisteredUserWithPersonCredentials(string email, Person person)
    {
        Email = email;
        Person = person;
    }

    public RegisteredUserWithPersonCredentials()
    {
    }
}