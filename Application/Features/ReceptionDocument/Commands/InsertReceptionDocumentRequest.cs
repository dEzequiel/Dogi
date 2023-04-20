using Application.DTOs.ReceptionDocument;
using Application.Service.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ReceptionDocument.Commands
{
    /// <summary>
    /// Insert ReceptionDocument request implementation.
    /// </summary>
    public class InsertReceptionDocumentRequest : IRequest<ApiResponse<ReceptionDocumentForGet>>
    {
        public ReceptionDocumentForAdd ReceptionDocumentData { get; private set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocumentData"></param>
        public InsertReceptionDocumentRequest(ReceptionDocumentForAdd receptionDocumentData) =>
            this.ReceptionDocumentData = receptionDocumentData;

    }

    /// <summary>
    /// Insert ReceptionDocument handler implementation.
    /// </summary>
    public class InsertReceptionDocumentRequestHandler : IRequestHandler<InsertReceptionDocumentRequest, 
                                                         ApiResponse<ReceptionDocumentForGet>>
    {
        private readonly ILogger<InsertReceptionDocumentRequestHandler> _logger;
        private readonly IReceptionDocumentWrite _receptionDocumentWriteService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentWriteService"></param>
        public InsertReceptionDocumentRequestHandler(ILogger<InsertReceptionDocumentRequestHandler> logger, 
            IReceptionDocumentWrite receptionDocumentWriteService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _receptionDocumentWriteService = Guard.Against.Null(receptionDocumentWriteService);
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<ReceptionDocumentForGet>> Handle(InsertReceptionDocumentRequest request, 
                                                                       CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));
            
            ReceptionDocumentForGet result = await _receptionDocumentWriteService.AddAsync(request.ReceptionDocumentData);

            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> End");

            return new ApiResponse<ReceptionDocumentForGet>(result);

        }
    }
}
