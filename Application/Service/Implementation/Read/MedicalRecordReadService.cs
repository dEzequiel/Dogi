using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class MedicalRecordReadService : IMedicalRecordReadService
{
    private readonly ILogger<MedicalRecordReadService> Logger;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public MedicalRecordReadService(ILogger<MedicalRecordReadService> logger, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<IEnumerable<MedicalRecord>> GetAllByStatusAsync(int statusId, CancellationToken ct = default)
    {
        Logger.LogInformation("MedicalRecordReadService --> GetAllByStatusAsync --> Start");

        Guard.Against.Null(statusId, nameof(statusId));

        var repository = UnitOfWork.MedicalRecordRepository;

        var records = await repository.GetAllByStatusAsync(statusId, ct);
        
        Logger.LogInformation("MedicalRecordReadService --> GetAllByStatusAsync --> End");

        return records;
    }

    ///<inheritdoc />
    public async Task<IEnumerable<MedicalRecord>> GetAllAsync()
    {
        Logger.LogInformation("MedicalRecordReadService --> GetAllAsync --> Start");
        
        var repository = UnitOfWork.MedicalRecordRepository;

        var records = await repository.GetAllAsync();
        
        Logger.LogInformation("MedicalRecordReadService --> GetAllAsync --> End");

        return records;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}