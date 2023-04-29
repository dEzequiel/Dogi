using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ReceptionDocument.Queries
{
    /// <summary>
    /// Get all ReceptionDocuments filtered bt chip possesion request implementation.
    /// </summary>
    public class GetAllReceptionDocumentsFilterByChipRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>>
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
    public class GetAllReceptionDocumentsFilterByChipRequestHandler : IRequestHandler<GetAllReceptionDocumentsFilterByChipRequest,
        ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>>
    {
        private readonly ILogger<GetAllReceptionDocumentsFilterByChipRequestHandler> _logger;
        private readonly IReceptionDocumentRead _receptionDocumentReadService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentReadService"></param>
        public GetAllReceptionDocumentsFilterByChipRequestHandler(ILogger<GetAllReceptionDocumentsFilterByChipRequestHandler> logger, 
            IReceptionDocumentRead receptionDocumentReadService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _receptionDocumentReadService = Guard.Against.Null(receptionDocumentReadService, nameof(receptionDocumentReadService));
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>> Handle(GetAllReceptionDocumentsFilterByChipRequest request, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAllReceptionDocumentsFilterByChipRequestHandler --> Handler --> Start");

            Guard.Against.Null(request, nameof(request));

            IEnumerable<Domain.Entities.ReceptionDocument> result = await _receptionDocumentReadService.GetAllFilterByChipAsync(request.HasChip,
                cancellationToken);

            _logger.LogInformation("GetAllReceptionDocumentsFilterByChipRequestHandler --> Handler --> End");

            return new ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>(result);
        }
    }
}
