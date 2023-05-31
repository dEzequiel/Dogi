namespace Application.DTOs.VeterinaryManager;

public class VaccinesToComplish
{
    public IEnumerable<Guid> Needed { get; set; }
    public IEnumerable<Guid> NotNeeded { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="needed"></param>
    /// <param name="notNeeded"></param>
    public VaccinesToComplish(IEnumerable<Guid> needed, IEnumerable<Guid> notNeeded)
    {
        Needed = needed;
        NotNeeded = notNeeded;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public VaccinesToComplish()
    {
    }
}