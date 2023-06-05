using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
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
    public async Task<AdoptionPending> AddAsync(AdoptionPending entity, AdminData adminData,
        CancellationToken ct = default)
    {
        _logger.LogInformation("AdoptionPendingWrite --> AddAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.IndividualProceedingId, nameof(entity.IndividualProceedingId));
        Guard.Against.Null(entity.AdoptionPendingStatusId, nameof(entity.AdoptionPendingStatusId));

        var repository = _unitOfWork.AdoptionPendingRepository;

        await repository.AddAsync(entity, adminData, ct);

        await _unitOfWork.CompleteAsync();

        _logger.LogInformation("AdoptionPendingWrite --> AddAsync --> End");

        return entity;
    }

    ///<inheritdoc />
    public async Task<bool> CloseAdoptionAsync(Guid id, AdminData adminData, CancellationToken ct = default)
    {
        _logger.LogInformation($"AdoptionPendingWrite --> CloseAdoptionAsync({id}) --> Start");

        Guard.Against.NullOrEmpty(id, nameof(id));
        Guard.Against.NullOrEmpty(adminData.Email, nameof(adminData.Email));
        Guard.Against.NullOrEmpty(adminData.Id, nameof(adminData.Id));

        var repository = _unitOfWork.AdoptionPendingRepository;

        var result = await repository.CloseAsync(id, adminData, ct);

        await _unitOfWork.CompleteAsync(ct);

        _logger.LogInformation("AdoptionPendingWrite --> CloseAdoptionAsync --> End");

        return result;
    }


    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}