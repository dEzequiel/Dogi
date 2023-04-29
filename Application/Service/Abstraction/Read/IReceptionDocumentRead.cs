using Crosscuting.Api.DTOs.Response;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Read;

/// <summary>
/// ReceptionDocument Read Service Definition.
/// </summary>
public interface IReceptionDocumentRead : IApplicationServiceBase
{
    /// <summary>
    /// Obtain ReceptionDocument by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ReceptionDocument?> GetByIdAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Obtain existing ReceptionDocuments.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ReceptionDocument>> GetAllAsync(CancellationToken ct = default);

    /// <summary>
    /// Obtain existing ReceptionDocuments filter with animal chip possession.
    /// </summary>
    /// <param name="hasChip"></param>
    /// <returns></returns>
    Task<IEnumerable<ReceptionDocument>?> GetAllFilterByChipAsync(bool hasChip, CancellationToken ct = default);
}