using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class VaccineRead : IVaccineReadService
{
    private readonly ILogger<VaccineRead> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public VaccineRead(ILogger<VaccineRead> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<IEnumerable<Vaccine>> GetAllByAnimalCategory(int categoryId, CancellationToken ct = default)
    {
        _logger.LogInformation("VaccineRead --> GetAllByAnimalCategory --> Start");

        var repository = _unitOfWork.VaccineRepository;

        var vaccines = await repository.GetAllByAnimalCategoryAsync(categoryId, ct);

        _logger.LogInformation("VaccineRead --> GetAllByAnimalCategory --> End");

        return vaccines;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}