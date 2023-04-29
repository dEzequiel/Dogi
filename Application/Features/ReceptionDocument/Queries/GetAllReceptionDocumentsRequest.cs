using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
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
    /// Get all ReceptionDocuments.
    /// </summary>
    public class GetAllReceptionDocumentsRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>> { }

    public class GetAllReceptionDocumentsRequestHandler : IRequestHandler<GetAllReceptionDocumentsRequest,
        ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>>
    {
        private readonly ILogger<GetReceptionDocumentByIdRequestHandler> _logger;
        private readonly IReceptionDocumentRead _receptionDocumentReadService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentReadService"></param>
        public GetAllReceptionDocumentsRequestHandler(ILogger<GetReceptionDocumentByIdRequestHandler> logger, 
            IReceptionDocumentRead receptionDocumentReadService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _receptionDocumentReadService = Guard.Against.Null(receptionDocumentReadService, nameof(receptionDocumentReadService));
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>> Handle(GetAllReceptionDocumentsRequest request, 
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("GetAllReceptionDocumentsRequestHandler --> Handler --> Start");

            Guard.Against.Null(request, nameof(request));

            IEnumerable<Domain.Entities.ReceptionDocument> result = await _receptionDocumentReadService.GetAllAsync(cancellationToken);

            _logger.LogInformation("GetAllReceptionDocumentsRequestHandler --> Handler --> End");

            return new ApiResponse<IEnumerable<Domain.Entities.ReceptionDocument>>(result);
        }
    }
}
