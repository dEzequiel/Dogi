﻿using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ReceptionDocument.Queries
{
    /// <summary>
    /// Get all ReceptionDocuments request implementation.
    /// </summary>
    public class
        GetAllReceptionDocumentsRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>>
    {
    }

    /// <summary>
    /// Get all ReceptionDocuments handler implementation.
    /// </summary>
    public class GetAllReceptionDocumentsRequestHandler : IRequestHandler<GetAllReceptionDocumentsRequest,
        ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>>
    {
        private readonly ILogger<GetReceptionDocumentByIdRequestHandler> _logger;
        private readonly IReceptionDocumentReadService _receptionDocumentReadService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentReadService"></param>
        public GetAllReceptionDocumentsRequestHandler(ILogger<GetReceptionDocumentByIdRequestHandler> logger,
            IReceptionDocumentReadService receptionDocumentReadService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _receptionDocumentReadService =
                Guard.Against.Null(receptionDocumentReadService, nameof(receptionDocumentReadService));
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>> Handle(
            GetAllReceptionDocumentsRequest request,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("GetAllReceptionDocumentsRequestHandler --> Handler --> Start");

            Guard.Against.Null(request, nameof(request));

            IEnumerable<Domain.Entities.Shelter.ReceptionDocument> result =
                await _receptionDocumentReadService.GetAllAsync(cancellationToken);

            _logger.LogInformation("GetAllReceptionDocumentsRequestHandler --> Handler --> End");

            return new ApiResponse<IEnumerable<Domain.Entities.Shelter.ReceptionDocument>>(result);
        }
    }
}