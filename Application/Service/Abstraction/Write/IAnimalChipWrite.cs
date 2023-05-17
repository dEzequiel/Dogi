using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Service.Abstraction.Write
{
    public interface IAnimalChipWrite
    {
        /// <summary>
        /// Add new AnimalChip.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<AnimalChip> AddAsync(AnimalChip entity, AdminData admin, CancellationToken ct = default);
    }
}
