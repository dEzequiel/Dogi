using Application.DTOs.ReceptionDocument;
using Application.Service.Abstraction;
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

        public InsertReceptionDocumentRequest(ReceptionDocumentForAdd receptionDocumentData)
        {
            ReceptionDocumentData = receptionDocumentData;
        }
    }

    /// <summary>
    /// Insert ReceptionDocument handler implementation.
    /// </summary>
    public class InsertReceptionDocumentRequestHandler : IRequestHandler<InsertReceptionDocumentRequest, ApiResponse<ReceptionDocumentForGet>>
    {
        private readonly ILogger<InsertReceptionDocumentRequestHandler> _logger;
        private readonly IReceptionDocumentWrite _receptionDocumentService;

        public InsertReceptionDocumentRequestHandler(ILogger<InsertReceptionDocumentRequestHandler> logger, IReceptionDocumentWrite receptionDocumentService)
        {
            _logger = logger;
            _receptionDocumentService = receptionDocumentService;
        }

        public async Task<ApiResponse<ReceptionDocumentForGet>> Handle(InsertReceptionDocumentRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> Start");

            ReceptionDocumentForGet result = await _receptionDocumentService.AddAsync(request.ReceptionDocumentData);

            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> End");

            return new ApiResponse<ReceptionDocumentForGet>(result);

        }
    }
}
