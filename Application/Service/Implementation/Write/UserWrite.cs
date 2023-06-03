using System.Security.Cryptography;
using Application.Authentication;
using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Authentication;
using Domain.Entities.Authorization;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write;

public class UserRead : IUserWriteService
{
    private readonly ILogger<UserRead> Logger;
    private readonly IUnitOfWork UnitOfWork;
    private readonly IJsonWebTokenProvider JsonWebTokenProvider;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public UserRead(ILogger<UserRead> logger, IUnitOfWork unitOfWork, IJsonWebTokenProvider jsonWebTokenProvider)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
        JsonWebTokenProvider = jsonWebTokenProvider;
    }

    ///<inheritdoc />
    public async Task<User> Register(UserDataRegister entity, CancellationToken ct = default)
    {
        Logger.LogInformation("UserWrite --> AddAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.Email, nameof(entity.Email));
        Guard.Against.NullOrEmpty(entity.Password, nameof(entity.Password));

        var repository = UnitOfWork.UserRepository;

        HashPassword(entity.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new User()
        {
            Email = entity.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await repository.AddAsync(user, ct);

        await UnitOfWork.CompleteAsync(ct);

        Logger.LogInformation("UserWrite --> AddAsync --> End");

        return user;
    }

    private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }


    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}