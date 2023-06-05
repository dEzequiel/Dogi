using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write;

public class AdoptionApplicationWrite : IAdoptionApplicationWriteService
{
    private readonly ILogger<AdoptionApplicationWrite> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionApplicationWrite(ILogger<AdoptionApplicationWrite> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionApplication> AddAsync(AdoptionApplication entity, UserData userData)
    {
        _logger.LogInformation("AdoptionApplicationWrite --> AddAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.AdoptionPendingId, nameof(entity.AdoptionPendingId));
        Guard.Against.NullOrEmpty(entity.UserId, nameof(entity.UserId));
        Guard.Against.Null(entity.HousingTypeId, nameof(entity.HousingTypeId));
        Guard.Against.Null(entity.AdoptionApplicationStatusId, nameof(entity.AdoptionApplicationStatusId));
        Guard.Against.Null(entity.HouseDescription, nameof(entity.HouseDescription));
        Guard.Against.NullOrEmpty(userData.Id, nameof(userData.Id));
        Guard.Against.NullOrEmpty(userData.Email, nameof(userData.Email));

        var repository = _unitOfWork.AdoptionApplicationRepository;

        await repository.AddAsync(entity, userData);

        await _unitOfWork.CompleteAsync();

        _logger.LogInformation("AdoptionApplicationWrite --> AddAsync --> End");

        return entity;
    }

    ///<inheritdoc />
    public async Task<bool> CompleteApplicationAsync(Guid id, AdminData adminData, CancellationToken ct = default)
    {
        _logger.LogInformation($"AdoptionApplicationWrite --> CompleteApplicationAsync({id}) --> Start");

        var repository = _unitOfWork.AdoptionApplicationRepository;

        var result = await repository.AcceptApplication(id, adminData, ct);

        await _unitOfWork.CompleteAsync();

        _logger.LogInformation("AdoptionApplicationWrite --> AddAsync --> End");

        return result;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}