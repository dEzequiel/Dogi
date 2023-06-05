using Domain.Entities.Adoption;

namespace Application.Interfaces;

public interface IHousingTypeRepository
{
    /// <summary>
    /// Get HousingType by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<HousingType> GetAsync(int id, CancellationToken ct = default);
}