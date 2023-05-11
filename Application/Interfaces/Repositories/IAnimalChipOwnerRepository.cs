using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities;


namespace Application.Interfaces.Repositories
{

    public interface IAnimalChipOwnerRepository : IRepository<AnimalChipOwner>
    {
        /// <summary>
        /// Add new AnimalChipOwner.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(AnimalChipOwner entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Get AnimalChipOwner by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<AnimalChipOwner> GetAsync(Guid id, CancellationToken ct = default);

        /// <summary>
        /// Get all AnimalChipOwners.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<AnimalChipOwner>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Mark AnimalChipOwner as deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync (Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing AnimalChipOwner.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, AnimalChipOwner newEntity, AdminData admin, CancellationToken ct = default);
    }
}
