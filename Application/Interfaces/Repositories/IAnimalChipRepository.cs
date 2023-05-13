using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IAnimalChipRepository : IRepository<AnimalChip>
    {
        /// <summary>
        /// Add a new AnimalChip.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(AnimalChip entity, AdminData admin, CancellationToken ct = default);
    }
}
