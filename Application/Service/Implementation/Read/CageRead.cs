using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read
{
    public class CageRead : ICageReadService
    {
        private readonly ILogger<CageRead> _logger;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public CageRead(ILogger<CageRead> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
            _logger = Guard.Against.Null(logger, nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<Cage> GetFreeCageByZone(int zoneId, CancellationToken ct = default)
        {
            _logger.LogInformation($"CageRead --> GetFreeCageByZone({zoneId}) --> Start");

            Guard.Against.Null(zoneId, nameof(zoneId));

            var repository = _unitOfWork.CageRepository;

            var cage = await repository.GetFreeCageByZoneAsync(zoneId, ct);

            _logger.LogInformation($"CageRead --> GetFreeCageByZone({zoneId}) --> End");

            return cage;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}