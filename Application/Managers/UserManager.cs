﻿using Application.DTOs.UserManager;
using Application.Features.Person.Commands;
using Application.Features.User.Commands;
using Application.Interfaces;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api;
using Crosscuting.Base.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers;

public class UserManager : IUserManager
{
    private readonly ILogger<UserManager> Logger;
    private readonly IMediator Mediator;
    private readonly IUnitOfWork UnitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <param name="unitOfWork"></param>
    public UserManager(ILogger<UserManager> logger, IMediator mediator, IUnitOfWork unitOfWork)
    {
        Logger = logger;
        Mediator = mediator;
        UnitOfWork = unitOfWork;
    }

    ///<inheritdoc />
    public async Task<RegisteredUserWithPersonCredentials> Register(UserDataRegister user,
        CancellationToken ct = default)
    {
        var userRepository = UnitOfWork.UserRepository;
        var userExist = await userRepository.GetAsync(user.Email);
        if (userExist is not null)
        {
            throw new DogiException("User with username already exist.");
        }

        var createdUser = await Mediator.Send(new RegisterUserRequest(user), ct);

        user.Person.User = createdUser.Data;

        var createdPerson = await Mediator.Send(new InsertPersonRequest(user.Person), ct);

        Guard.Against.Null(createdUser.Data);
        Guard.Against.Null(createdPerson.Data);

        return new RegisteredUserWithPersonCredentials()
        {
            Email = createdUser.Data.Email,
            Person = createdPerson.Data
        };
    }

    ///<inheritdoc />
    public async Task<string> Authenticate(UserDataRegister user, CancellationToken ct = default)
    {
        var result = await Mediator.Send(new AuthenticateUserRequest(user), ct);

        return result;
    }

    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}