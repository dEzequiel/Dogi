using Crosscuting.Base.Interfaces;

namespace Application.Service.Abstraction.Write
{
    public interface ICageWrite : IApplicationServiceBase
    {
        /// <summary>
        /// Update the occupied status of the cage.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateOccupiedStatusAsync(Guid id, CancellationToken cancellationToken);
    }
}
