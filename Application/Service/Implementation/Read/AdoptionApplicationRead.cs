using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class AdoptionApplicationRead : IAdoptionApplicationReadService
{
    private readonly ILogger<AdoptionApplicationRead> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Contructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionApplicationRead(ILogger<AdoptionApplicationRead> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionApplication> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        _logger.LogInformation($"AdoptionApplicationRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.Null(id, nameof(id));

        var repository = _unitOfWork.AdoptionApplicationRepository;

        var application = await repository.GetAsync(id, ct);

        _logger.LogInformation($"AdoptionApplicationRead --> GetByIdAsync --> End");

        return application;
    }

    ///<inheritdoc />
    public async Task<IEnumerable<AdoptionApplication>> GetAllByAdoptionPendingIdAsync(Guid adoptionPendingId,
        CancellationToken ct = default)
    {
        _logger.LogInformation($"AdoptionApplicationRead --> GetAllByAdoptionPendingId({adoptionPendingId}) --> Start");

        Guard.Against.NullOrEmpty(adoptionPendingId, nameof(adoptionPendingId));

        var repository = _unitOfWork.AdoptionApplicationRepository;

        var applications = await repository.GetAllByAdoptionPendingIdAsync(adoptionPendingId, ct);

        _logger.LogInformation($"AdoptionApplicationRead --> GetByIdAsync --> End");

        return applications;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}