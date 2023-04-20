namespace Crosscuting.Api.DTOs.Response;

/// <summary>
/// A Page Response is an api response with a enumeration of items and information about total items in the non paginated collection
/// </summary>
/// <remarks>Returning objects implementing this interface from controllers will produce <see cref="PaginatedApiResponse{TData}"/> responses from API</remarks>
/// <typeparam name="TData">Page items type</typeparam>
public interface IPageResponse<out TData> where TData : class
{
    /// <summary>
    /// Page items
    /// </summary>
    TData Data { get; }

    /// <summary>
    /// Total number of items (including all pages)
    /// </summary>
    int TotalCount { get; }

    /// <summary>
    /// Current page
    /// </summary>
    int NumPage { get; }

    /// <summary>
    /// Items on each page
    /// </summary>
    int PageSize { get; }

    /// <summary>
    /// Total pages
    /// </summary>
    int TotalPages { get; }
}