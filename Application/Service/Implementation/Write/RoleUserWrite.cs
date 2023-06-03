using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Domain.Entities.Authorization;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write;

public class RoleUserWrite : IRoleUserWriteService
{
    private readonly ILogger<RoleUserWrite> Logger;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public RoleUserWrite(ILogger<RoleUserWrite> logger, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<IEnumerable<RoleUser>> AddAsync(Guid userId, IEnumerable<int> rolesIds,
        CancellationToken ct = default)
    {
        Logger.LogInformation("RoleUserWrite --> AddAsync --> Start");

        Guard.Against.Null(userId, nameof(userId));
        Guard.Against.NullOrEmpty(rolesIds, nameof(rolesIds));

        var repository = UnitOfWork.RoleUserRepository;

        var entities = await repository.AddAsync(userId, rolesIds, ct);

        await UnitOfWork.CompleteAsync();

        Logger.LogInformation("RoleUserWrite --> AddAsync --> End");

        return entities;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}