﻿using Domain.Entities.Authorization;

namespace Application.Interfaces.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Add new User.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task AddAsync(User user, CancellationToken ct = default);

    /// <summary>
    /// Get username by name.
    /// </summary>
    /// <returns></returns>
    Task<User> GetAsync(string username, CancellationToken ct = default);

    /// <summary>
    /// Get username by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<User> GetAsync(Guid id, CancellationToken ct = default);
}