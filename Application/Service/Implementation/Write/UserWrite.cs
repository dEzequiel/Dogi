using System.Security.Cryptography;
using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write;

public class UserWrite : IUserWriteService
{
    private readonly ILogger<UserWrite> Logger;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public UserWrite(ILogger<UserWrite> logger, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
    }
    
    ///<inheritdoc />
    public async Task<User> AddAsync(UserData entity, CancellationToken ct = default)
    {
        Logger.LogInformation("UserWrite --> AddAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.Username, nameof(entity.Username));
        Guard.Against.NullOrEmpty(entity.Password, nameof(entity.Password));

        var repository = UnitOfWork.UserRepository;
        
        HashPassword(entity.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new User()
        {
            Username = entity.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        
        await repository.AddAsync(user, ct);

        await UnitOfWork.CompleteAsync(ct);
        
        Logger.LogInformation("UserWrite --> AddAsync --> End");

        return user;
    }

    ///<inheritdoc />
    public async Task<bool> LoginAsync(UserData entity, CancellationToken ct = default)
    {
        Logger.LogInformation("UserWrite --> LoginAsync --> Start");

        Guard.Against.Null(entity, nameof(entity));
        Guard.Against.NullOrEmpty(entity.Username, nameof(entity.Username));
        Guard.Against.NullOrEmpty(entity.Password, nameof(entity.Password));

        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetAsync(entity.Username, ct);
        if (user is null)
        {
            // El usuario no existe en la base de datos
            Logger.LogInformation("UserWrite --> LoginAsync --> User not found");
            throw new DogiException("User not found.");
        }

        if (!VerifyPasswordHash(entity.Password, user.PasswordHash, user.PasswordSalt))
        {
            Logger.LogInformation("UserWrite --> LoginAsync --> Incorrect password");
            return false;
        }

        // La autenticación fue exitosa
        Logger.LogInformation("UserWrite --> LoginAsync --> Successful authentication");
        return true;
    }
    
    private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
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

        // La contraseña coincide
        return true;
    }
    
    
    ///<inheritdoc />
    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}