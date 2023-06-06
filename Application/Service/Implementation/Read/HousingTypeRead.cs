using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class HousingTypeRead : IHousingTypeReadService
{
    private readonly ILogger<HousingTypeRead> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public HousingTypeRead(ILogger<HousingTypeRead> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<HousingType> GetByIdAsync(int id, CancellationToken ct = default)
    {
        _logger.LogInformation($"HousingTypeRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.Null(id, nameof(id));

        var repository = _unitOfWork.HousingTypeRepository;

        var housingType = await repository.GetAsync(id, ct);

        _logger.LogInformation($"HousingTypeRead --> GetByIdAsync --> End");

        return housingType;
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}