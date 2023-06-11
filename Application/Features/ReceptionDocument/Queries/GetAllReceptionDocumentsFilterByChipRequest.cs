using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ReceptionDocument.Queries
{
    /// <summary>
    /// Get all ReceptionDocuments filtered bt chip possesion request implementation.
    /// </summary>
    public class
        GetAllReceptionDocumentsFilterByChipRequest : IRequest<
            ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>>
    {
        public bool HasChip { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="hasChip"></param>
        public GetAllReceptionDocumentsFilterByChipRequest(bool hasChip)
        {
            HasChip = hasChip;
        }
    }

    /// <summary>
    /// Get all ReceptionDocuments filtered bt chip possesion handler implementation.
    /// </summary>
    public class GetAllReceptionDocumentsFilterByChipRequestHandler : IRequestHandler<
        GetAllReceptionDocumentsFilterByChipRequest,
        ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>>
    {
        private readonly ILogger<GetAllReceptionDocumentsFilterByChipRequestHandler> _logger;
        private readonly IReceptionDocumentReadService _receptionDocumentReadService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentReadService"></param>
        public GetAllReceptionDocumentsFilterByChipRequestHandler(
            ILogger<GetAllReceptionDocumentsFilterByChipRequestHandler> logger,
            IReceptionDocumentReadService receptionDocumentReadService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _receptionDocumentReadService =
                Guard.Against.Null(receptionDocumentReadService, nameof(receptionDocumentReadService));
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>> Handle(
            GetAllReceptionDocumentsFilterByChipRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAllReceptionDocumentsFilterByChipRequestHandler --> Handler --> Start");

            Guard.Against.Null(request, nameof(request));

            IEnumerable<Domain.Entities.Shelter.ReceptionDocument>? result =
                await _receptionDocumentReadService.GetAllFilterByChipAsync(request.HasChip,
                    cancellationToken);

            _logger.LogInformation("GetAllReceptionDocumentsFilterByChipRequestHandler --> Handler --> End");

            return new ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>(result!);
        }
    }
}