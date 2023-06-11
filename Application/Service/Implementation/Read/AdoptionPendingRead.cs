using Application.Interfaces;
using Application.Service.Abstraction;
using Ardalis.GuardClauses;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class AdoptionPendingRead : IAdoptionPendingReadService
{
    private readonly ILogger<AdoptionPendingRead> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionPendingRead(ILogger<AdoptionPendingRead> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionPending> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        _logger.LogInformation($"AdoptionPendingRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.Null(id, nameof(id));

        var repository = _unitOfWork.AdoptionPendingRepository;

        var entity = await repository.GetAsync(id, ct);

        _logger.LogInformation("AdoptionPendingRead --> GetByIdAsync --> End");

        return entity;
    }

    ///<inheritdoc />
    public async Task<IEnumerable<AdoptionPending>> GetAllByStatusIdAsync(int status, CancellationToken ct = default)
    {
        _logger.LogInformation("AdoptionPendingRead --> GetAllByStatusIdAsync --> Start");

        Guard.Against.Null(status, nameof(status));

        var repository = _unitOfWork.AdoptionPendingRepository;

        var entities = await repository.GetAllByStatus(status);

        _logger.LogInformation("AdoptionPendingRead --> GetAllByStatusIdAsync --> End");

        return entities;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}