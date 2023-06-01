﻿using Domain.Common;

namespace Domain.Entities;

/// <summary>
/// Represents the user.
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Username.
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// Stores the hashed value of the user's password.
    /// </summary>
    public byte[] PasswordHash { get; set; }
    /// <summary>
    /// Added text.
    /// </summary>
    public byte[] PasswordSalt { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="username"></param>
    /// <param name="passwordHash"></param>
    /// <param name="passwordSalt"></param>
    public User(Guid id, string username, byte[] passwordHash, byte[] passwordSalt) : base(id)
    {
        Username = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"></param>
    public User(Guid id) : base(id) { }
    /// <summary>
    /// Constructor.
    /// </summary>
    public User() : base(Guid.NewGuid()) { }

}