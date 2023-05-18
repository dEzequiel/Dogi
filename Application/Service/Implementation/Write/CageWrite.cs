using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class CageWrite : ICageWrite
    {
        private readonly ILogger<CageWrite> _logger;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public CageWrite(ILogger<CageWrite> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        ///<inheritdoc />
        public async Task<bool> UpdateOccupiedStatusAsync(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CageWrite --> UpdateOccupiedStatusAsync({id}) --> Start");

            Guard.Against.NullOrEmpty(id, nameof(id));

            var repository = _unitOfWork.CageRepository;

            await repository.UpdateOccupiedStatusAsync(id, cancellationToken);

            await _unitOfWork.CompleteAsync(cancellationToken);

            _logger.LogInformation($"CageWrite --> UpdateOccupiedStatusAsync({id}) --> End");

            return true;
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
