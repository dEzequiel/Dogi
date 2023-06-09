﻿using Application.Service.Interfaces;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IVaccineRepository : IRepository<Vaccine>
    {
        /// <summary>
        /// Add new Vaccine.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(Vaccine entity, CancellationToken ct = default);

        /// <summary>
        /// Add collection of Vaccine.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<Vaccine> entities, CancellationToken ct = default);

        /// <summary>
        /// Get all vaccines filter by category. If no category given return all vaccines.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<Vaccine>> GetAllByAnimalCategoryAsync(int category, CancellationToken ct = default);
    }
}