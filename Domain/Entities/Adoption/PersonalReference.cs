namespace Domain.ValueObjects;

public class PersonalReference
{
    /// <summary>
    /// Reference name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Reference lastname.
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Reference contact.
    /// </summary>
    public string Contact { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="lastname"></param>
    /// <param name="contact"></param>
    public PersonalReference(string name, string lastname, string contact)
    {
        Name = name;
        Lastname = lastname;
        Contact = contact;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public PersonalReference()
    {
    }
}