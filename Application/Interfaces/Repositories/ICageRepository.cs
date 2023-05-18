﻿using Application.Service.Interfaces;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ICageRepository : IRepository<Cage>
    {
        /// <summary>
        /// Update the occupied status of the cage.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateOccupiedStatusAsync(Guid id, CancellationToken ct = default);
    }
}
