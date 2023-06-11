﻿using Application.DTOs.User;
using Crosscuting.Api.DTOs.Authentication;
using Crosscuting.Base.Interfaces;
using Domain.Entities.Authorization;

namespace Application.Service.Abstraction.Read;

public interface IUserReadService : IApplicationServiceBase
{
    /// <summary>
    /// Get user by identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<User> GetByIdAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Authenticate user credentials.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<UserWithToken> Authenticate(UserDataLogin entity, CancellationToken ct = default);
}