using Application.Service.Interfaces;
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
        Task AddAsync(AnimalChip entity, CancellationToken ct = default);
    }
}
