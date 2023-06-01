using System.Security.Cryptography;
using Application.Service.Abstraction.Read;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read;

public class UserReadService : IUserReadService
{
    private readonly ILogger<UserReadService> Logger;
    private readonly IUnitOfWork UnitOfWork;
    private readonly IJsonWebTokenProvider JsonWebTokenProvider;


    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public UserReadService(ILogger<UserReadService> logger, IUnitOfWork unitOfWork, IJsonWebTokenProvider
        jsonWebTokenProvider)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
        JsonWebTokenProvider = jsonWebTokenProvider;
    }

    ///<inheritdoc />
    public async Task<User> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        Logger.LogInformation($"SexRead --> GetByIdAsync({id}) --> Start");

        Guard.Against.Null(id, nameof(id));

        var repository = UnitOfWork.UserRepository;

        var entity = await repository.GetAsync(id);

        Logger.LogInformation($"SexRead --> GetByIdAsync({id}) --> End");

        return entity;
    }

    ///<inheritdoc />
    public async Task<string> Authenticate(UserDataRegister entity, CancellationToken ct = default)
    {
        Logger.LogInformation("UserWrite --> LoginAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.Email, nameof(entity.Email));
        Guard.Against.NullOrEmpty(entity.Password, nameof(entity.Password));

        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetAsync(entity.Email, ct);
        if (user is null)
        {
            Logger.LogInformation("UserWrite --> LoginAsync --> User not found");
            throw new DogiException("User not found.");
        }

        if (!VerifyPasswordHash(entity.Password, user.PasswordHash, user.PasswordSalt))
        {
            Logger.LogInformation("UserWrite --> LoginAsync --> Incorrect password");
            throw new DogiException("Password does not match.");
        }

        Logger.LogInformation("UserWrite --> LoginAsync --> End");

        string token = JsonWebTokenProvider.Generate(user);

        return token;
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using (var hmac = new HMACSHA512(storedSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}