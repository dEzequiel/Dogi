using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write;

public class AdoptionPendingWrite : IAdoptionPendingWriteService
{
    private readonly ILogger<AdoptionPendingWrite> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionPendingWrite(ILogger<AdoptionPendingWrite> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionPending> AddAsync(AdoptionPending entity, CancellationToken ct = default)
    {
        _logger.LogInformation("AdoptionPendingWrite --> AddAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.IndividualProceedingId, nameof(entity.IndividualProceedingId));
        Guard.Against.Null(entity.AdoptionPendingStatusId, nameof(entity.AdoptionPendingStatusId));

        var repository = _unitOfWork.AdoptionPendingRepository;

        await repository.AddAsync(entity, ct);

        await _unitOfWork.CompleteAsync();

        _logger.LogInformation("AdoptionPendingWrite --> AddAsync --> End");

        return entity;
    }


    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}