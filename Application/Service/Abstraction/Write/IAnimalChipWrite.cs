using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Service.Abstraction.Write
{
    public interface IAnimalChipWrite : IApplicationServiceBase
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
