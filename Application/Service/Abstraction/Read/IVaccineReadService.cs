using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Read;

public interface IVaccineReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get all vaccines filter by animal category.
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<Vaccine>> GetAllByAnimalCategory(int categoryId, CancellationToken ct = default);
}