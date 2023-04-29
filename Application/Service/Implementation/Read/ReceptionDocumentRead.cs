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
    private readonly ILogger<ReceptionDocumentWrite> _logger;
    private readonly IUnitOfWork _unitOfWork;
    
    public ReceptionDocumentRead(IUnitOfWork unitOfWork, ILogger<ReceptionDocumentWrite> logger)
    {
        _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
        _logger = Guard.Against.Null(logger, nameof(logger));
    }
    
    /// <inheritdoc/>
    public async Task<ReceptionDocument?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        _logger.LogInformation($"ReceptionDocumentRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.NullOrEmpty(id, nameof(id));
        
        var repository = _unitOfWork.ReceptionDocumentRepository;

        var document = await repository.GetAsync(id);
        
        _logger.LogInformation($"ReceptionDocumentRead --> GetByIdAsync({id}) --> End");

        return document;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ReceptionDocument>> GetAllAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedAsync --> Start");

        var repository = _unitOfWork.ReceptionDocumentRepository;

        var documents = await repository.GetAllAsync(ct);
        
        _logger.LogInformation("ReceptionDocumentRead --> GetAllPaginatedAsync --> End");

        return documents;
    }

    public async Task<IEnumerable<ReceptionDocument>> GetAllFilterByChipAsync(bool hasChip, CancellationToken ct = default)
    {
        _logger.LogInformation($"ReceptionDocumentRead --> GetAllFilterByChipAsync({hasChip}) --> Start");

        var repository = _unitOfWork.ReceptionDocumentRepository;


        var documents = await repository.GetAllFilterByChipPossessionAsync(hasChip, ct);
        
        _logger.LogInformation("ReceptionDocumentRead --> GetAllFilterByChipAsync --> End");

        return documents;
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