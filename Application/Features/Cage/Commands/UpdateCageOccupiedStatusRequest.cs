using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Cage.Commands
{
    public class UpdateCageOccupiedStatusRequest : IRequest<ApiResponse<bool>>
    {
        public Guid CageId { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cageId"></param>
        public UpdateCageOccupiedStatusRequest(Guid cageId)
        {
            CageId = cageId;
        }

    }

    public class UpdateCageOccupiedStatusRequestHandler : IRequestHandler<UpdateCageOccupiedStatusRequest,
                                                            ApiResponse<bool>>
    {
        private readonly ILogger<UpdateCageOccupiedStatusRequestHandler> _logger;
        private readonly ICageWrite _cageWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        public UpdateCageOccupiedStatusRequestHandler(ILogger<UpdateCageOccupiedStatusRequestHandler> logger, ICageWrite cageWrite)
        {
            _logger = logger;
            _cageWrite = cageWrite;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<bool>> Handle(UpdateCageOccupiedStatusRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateCageOccupiedStatusRequestHandler --> UpdateOccupiedStatus --> Start");

            Guard.Against.Null(request, nameof(request));

            bool result = await _cageWrite.UpdateOccupiedStatusAsync(request.CageId, cancellationToken);

            return new ApiResponse<bool>(result);
        }
    }
}
