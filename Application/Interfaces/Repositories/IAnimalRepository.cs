using Crosscuting.Api.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Service.Interfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        /// <summary>
        /// Add new Animal.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(Animal entity, AdminData admin, CancellationToken ct = default);
        
        /// <summary>
        /// Get all Animals.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<Animal>> GetAllAsync(CancellationToken ct = default);
        
        /// <summary>
        /// Get all Animals filtered by category.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<Animal>> GetAllFilterByCategoryAsync(AnimalCategory category, CancellationToken ct = default);
        
        /// <summary>
        /// Mark Animal as deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing Animal.
        /// </summary>
        /// <param name=""></param>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid, Animal entity, AdminData admin, CancellationToken ct = default);
    }
}
