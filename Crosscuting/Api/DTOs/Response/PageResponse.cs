namespace Crosscuting.Api.DTOs.Response;

/// <inheritdoc/>
public sealed class PageResponse<TData> : IPageResponse<TData> where TData : class
{
    /// <inheritdoc/>
    public TData Data { get; set; }

    /// <inheritdoc/>
    public int TotalCount { get; set; }

    public int NumPage { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public int TotalPages => PageSize > 0
        ? (int)Math.Ceiling(TotalCount / (double)PageSize)
        : 0;
}