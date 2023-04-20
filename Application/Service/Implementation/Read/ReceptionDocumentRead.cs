using Application.DTOs.ReceptionDocument;
using Application.Service.Abstraction.Read;
using Application.Service.Implementation.Command;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using Crosscuting.Api.DTOs.Response;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Crosscuting.Base.Exceptions;

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
    public async Task<ReceptionDocumentForGet?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation($"ReceptionDocumentRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.NullOrEmpty(id, nameof(id));
        
        var repository = _unitOfWork.ReceptionDocumentRepository;

        var document = await repository.GetAsync(id);

        var validDocument = _receptionDocument.Verify(document);

        if (validDocument.IsFailure)
        {
            _logger.LogInformation("ReceptionDocumentWrite --> AddAsync --> Error");
            throw new Crosscuting.Base.Exceptions.InvalidDataException(validDocument.Error.Message);
        }
        
        var result = _mapper.Map<ReceptionDocumentForGet>(validDocument.Value);

        _logger.LogInformation($"ReceptionDocumentRead --> GetByIdAsync({id}) --> End");

        return result;
    }

    /// <inheritdoc/>
    public async Task<PageResponse<IEnumerable<ReceptionDocumentForGet>>> GetAllPaginatedAsync(PaginatedRequest paginated)
    {
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedAsync --> Start");

        var repository = _unitOfWork.ReceptionDocumentRepository;

        int totalCount = await repository.GetAllCountAsync();

        var documents = await repository.GetAllPaginatedAsync(paginated);

        var result = _mapper.Map<IEnumerable<ReceptionDocumentForGet>>(documents);
        
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedAsync --> End");

        return new PageResponse<IEnumerable<ReceptionDocumentForGet>>()
        {
            Data = result,
            TotalCount = totalCount,
            NumPage = paginated.NumPage,
            PageSize = paginated.PageSize
        };
    }

    public async Task<PageResponse<IEnumerable<ReceptionDocumentForGet>>> GetAllPaginatedFilterByChipPossession
        (PaginatedRequest paginated, bool hasChip)
    {
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedFilterByChipPossession --> Start");

        var repository = _unitOfWork.ReceptionDocumentRepository;

        int totalCount = await repository.GetAllCountAsync();

        var documents = await repository.GetAllPaginatedFilterByChipPossessionAsync(paginated, hasChip);

        var result = _mapper.Map<IEnumerable<ReceptionDocumentForGet>>(documents);
        
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedFilterByChipPossession --> End");

        return new PageResponse<IEnumerable<ReceptionDocumentForGet>>()
        {
            Data = result,
            TotalCount = totalCount,
            NumPage = paginated.NumPage,
            PageSize = paginated.PageSize
        };
    }

    public Task<PageResponse<IEnumerable<ReceptionDocumentForGet>>?> GetAllByChipAsync(bool hasChip)
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}