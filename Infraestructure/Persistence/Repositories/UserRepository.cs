﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infraestructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private const string USER_NOT_FOUND = "Username with name {0} not found";
    protected DbSet<User> Users;
    
    /// <summary>
    /// Constrcutor.
    /// </summary>
    /// <param name="context"></param>
    public UserRepository(ApplicationDbContext context)
    {
        Users = context.Set<User>();
    }
    
    ///<inheritdoc />
    public async Task AddAsync(User user, CancellationToken ct = default)
    {
        await Users.AddAsync(user, ct);
    }

    ///<inheritdoc />
    public async Task<User> GetAsync(string username, CancellationToken ct = default)
    {
        return await Users.FirstOrDefaultAsync(x => x.Username == username);
    }
}