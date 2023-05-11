using Crosscuting.Api.DTOs;
using Domain.Entities;


namespace Application.Service.Abstraction.Write
{
    /// <summary>
    /// AnimalChipOwner Write Service Definition.
    /// </summary>
    public interface IAnimalChipOwnerWrite
    {
        /// <summary>
        /// Add new AnimalChipOwner.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<AnimalChipOwner> AddAsync(AnimalChipOwner entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Soft delete existing AnimalChipOwner.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing AnimalChipOwner.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<AnimalChipOwner> UpdateAsync(Guid id, AnimalChipOwner newEntity, AdminData admin, CancellationToken ct = default);
    }
}
