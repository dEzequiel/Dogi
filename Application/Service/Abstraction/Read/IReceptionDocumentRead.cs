using Application.DTOs.ReceptionDocument;
using Crosscuting.Api.DTOs.Response;
using Crosscuting.Base.Interfaces;

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
    Task<ReceptionDocumentForGet?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtain existing ReceptionDocuments.
    /// </summary>
    /// <returns></returns>
    Task<PageResponse<IEnumerable<ReceptionDocumentForGet>>> GetAllPaginatedAsync(PaginatedRequest paginated);

    /// <summary>
    /// Obtain existing ReceptionDocuments filter by chip possession.
    /// </summary>
    /// <param name="paginated"></param>
    /// <param name="hasChip"></param>
    /// <returns></returns>
    Task<PageResponse<IEnumerable<ReceptionDocumentForGet>>> GetAllPaginatedFilterByChipPossession(PaginatedRequest paginated,
                                                                                                    bool hasChip);
    /// <summary>
    /// Obtain existing ReceptionDocuments filter with animal chip possession.
    /// </summary>
    /// <param name="hasChip"></param>
    /// <returns></returns>
    Task<PageResponse<IEnumerable<ReceptionDocumentForGet>>?> GetAllByChipAsync(bool hasChip);
}