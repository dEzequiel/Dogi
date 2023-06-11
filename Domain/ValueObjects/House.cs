using Domain.Common;

namespace Domain.ValueObjects;

public class House : ValueObject
{
    /// <summary>
    /// Number of rooms.
    /// </summary>
    public int Rooms { get; }

    /// <summary>
    /// Has courtyard.
    /// </summary>
    public bool HasCourtyard { get; }

    /// <summary>
    /// Number of persons.
    /// </summary>
    public int Persons { get; }

    /// <summary>
    /// House persons age range.
    /// </summary>
    public int AgeRange { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="rooms"></param>
    /// <param name="hasCourtyard"></param>
    /// <param name="persons"></param>
    /// <param name="ageRange"></param>
    public House(int rooms, bool hasCourtyard, int persons, int ageRange)
    {
        Rooms = rooms;
        HasCourtyard = hasCourtyard;
        Persons = persons;
        AgeRange = ageRange;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public House()
    {
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Rooms;
        yield return HasCourtyard;
        yield return Persons;
        yield return AgeRange;
    }
}