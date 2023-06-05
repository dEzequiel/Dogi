using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class AdoptionApplicationStatusRead : IAdoptionApplicationStatusReadService
{
    private readonly ILogger<AdoptionApplicationStatusRead> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionApplicationStatusRead(ILogger<AdoptionApplicationStatusRead> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionApplicationStatus> GetByIdAsync(int id, CancellationToken ct = default)
    {
        _logger.LogInformation($"AdoptionApplicationStatusRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.Null(id, nameof(id));

        var repository = _unitOfWork.AdoptionApplicationStatusRepository;

        var status = await repository.GetAsync(id, ct);

        _logger.LogInformation($"AdoptionApplicationStatusRead --> GetByIdAsync --> End");

        return status;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}