using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Domain.Entities.Adoption;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write;

public class AdoptionApplicationWrite : IAdoptionApplicationWriteService
{
    private readonly ILogger<AdoptionApplicationWrite> Logger;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public AdoptionApplicationWrite(ILogger<AdoptionApplicationWrite> logger, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<AdoptionApplication> AddAsync(AdoptionApplication entity, UserData userData)
    {
        Logger.LogInformation("AdoptionApplicationWrite --> AddAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.AdoptionPendingId, nameof(entity.AdoptionPendingId));
        Guard.Against.NullOrEmpty(entity.UserId, nameof(entity.UserId));
        Guard.Against.Null(entity.HousingTypeId, nameof(entity.HousingTypeId));
        Guard.Against.Null(entity.AdoptionApplicationStatusId, nameof(entity.AdoptionApplicationStatusId));
        Guard.Against.Null(entity.HouseDescription, nameof(entity.HouseDescription));
        Guard.Against.NullOrEmpty(userData.Id, nameof(userData.Id));
        Guard.Against.NullOrEmpty(userData.Email, nameof(userData.Email));

        var repository = UnitOfWork.AdoptionApplicationRepository;

        await repository.AddAsync(entity, userData);

        await UnitOfWork.CompleteAsync();

        Logger.LogInformation("AdoptionApplicationWrite --> AddAsync --> End");

        return entity;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}