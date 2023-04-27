using Application.Service.Abstraction.Read;
using Application.Service.Implementation.Command;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

/// <summary>
/// ReceptionDocument Read Service Implementation.
/// </summary>
public class ReceptionDocumentRead : IReceptionDocumentRead
{
    private readonly ReceptionDocument _receptionDocument;
    private readonly ILogger<ReceptionDocumentWrite> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ReceptionDocumentRead(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReceptionDocumentWrite> logger, 
        ReceptionDocument receptionDocument)
    {
        _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
        _mapper = Guard.Against.Null(mapper, nameof(mapper));
        _logger = Guard.Against.Null(logger, nameof(logger));
        _receptionDocument = Guard.Against.Null(receptionDocument, nameof(receptionDocument));
    }
    
    /// <inheritdoc/>
    public async Task<ReceptionDocument?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation($"ReceptionDocumentRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.NullOrEmpty(id, nameof(id));
        
        var repository = _unitOfWork.ReceptionDocumentRepository;

        var document = await repository.GetAsync(id);
        
        _logger.LogInformation($"ReceptionDocumentRead --> GetByIdAsync({id}) --> End");

        return document;
    }

    /// <inheritdoc/>
    public async Task<PageResponse<IEnumerable<ReceptionDocument>>> GetAllPaginatedAsync(PaginatedRequest paginated)
    {
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedAsync --> Start");

        var repository = _unitOfWork.ReceptionDocumentRepository;

        int totalCount = await repository.GetAllCountAsync();

        var documents = await repository.GetAllPaginatedAsync(paginated);
        
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedAsync --> End");

        return new PageResponse<IEnumerable<ReceptionDocument>>()
        {
            Data = documents,
            TotalCount = totalCount,
            NumPage = paginated.NumPage,
            PageSize = paginated.PageSize
        };
    }

    public async Task<PageResponse<IEnumerable<ReceptionDocument>>> GetAllPaginatedFilterByChipPossession
        (PaginatedRequest paginated, bool hasChip)
    {
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedFilterByChipPossession --> Start");

        var repository = _unitOfWork.ReceptionDocumentRepository;

        int totalCount = await repository.GetAllCountAsync();

        var documents = await repository.GetAllPaginatedFilterByChipPossessionAsync(paginated, hasChip);
        
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedFilterByChipPossession --> End");

        return new PageResponse<IEnumerable<ReceptionDocument>>()
        {
            Data = documents,
            TotalCount = totalCount,
            NumPage = paginated.NumPage,
            PageSize = paginated.PageSize
        };
    }

    public Task<PageResponse<IEnumerable<ReceptionDocument>>?> GetAllByChipAsync(bool hasChip)
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}