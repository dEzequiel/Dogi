using Domain.Common;

namespace Domain.ValueObjects;

public class OtherAnimal : ValueObject
{
    /// <summary>
    /// Animal specie.
    /// </summary>
    public string Specie { get; set; }

    /// <summary>
    /// Animal age.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="specie"></param>
    /// <param name="age"></param>
    public OtherAnimal(string specie, int age)
    {
        Specie = specie;
        Age = age;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Specie;
        yield return Age;
    }
}