namespace Crosscuting.Api.DTOs.Response;

/// <summary>
/// Request to standardize entries to APIs
/// </summary>
public class PaginatedRequest
{
    /// <summary>
    /// Number of the page
    /// </summary>
    public virtual int NumPage { get; set; }

    /// <summary>
    /// Size of the page
    /// </summary>
    public virtual int PageSize { get; set; }
}