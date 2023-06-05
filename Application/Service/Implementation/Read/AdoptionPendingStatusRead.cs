using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class AdoptionPendingStatusRead : IAdoptionPendingStatusReadService
{
    private readonly ILogger<AdoptionPendingStatus> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionPendingStatusRead(ILogger<AdoptionPendingStatus> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<AdoptionPendingStatus> GetByIdAsync(int id, CancellationToken ct = default)
    {
        _logger.LogInformation($"AdoptionPendingStatusRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.Null(id, nameof(id));

        var repository = _unitOfWork.AdoptionPendingStatusRepository;

        var status = await repository.GetAsync(id, ct);

        _logger.LogInformation($"AdoptionPendingStatusRead --> GetByIdAsync --> End");

        return status;
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}