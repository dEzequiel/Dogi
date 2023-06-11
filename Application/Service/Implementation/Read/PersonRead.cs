using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class PersonRead : IPersonReadService
{
    private readonly ILogger<PersonRead> Logger;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Contructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public PersonRead(ILogger<PersonRead> logger, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<Person> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        Logger.LogInformation($"PersonRead --> GetByUserIdAsync({userId}) --> Start");

        Guard.Against.NullOrEmpty(userId, nameof(userId));

        var repository = UnitOfWork.PersonRepository;

        var person = await repository.GetByUserIdAsync(userId, ct);

        Logger.LogInformation($"PersonRead --> GetByUserIdAsync --> End");

        return person;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}