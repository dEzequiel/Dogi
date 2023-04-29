using Application.Service.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ReceptionDocument.Commands
{
    /// <summary>
    /// Insert ReceptionDocument request implementation.
    /// </summary>
    public class InsertReceptionDocumentRequest : IRequest<ApiResponse<Domain.Entities.ReceptionDocument>>
    {
        public Domain.Entities.ReceptionDocument ReceptionDocumentData { get; private set; } = null!;
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocumentData"></param>
        /// <param name="adminData"></param>
        public InsertReceptionDocumentRequest(Domain.Entities.ReceptionDocument receptionDocumentData, AdminData adminData)
        {
            ReceptionDocumentData = receptionDocumentData;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Insert ReceptionDocument handler implementation.
    /// </summary>
    public class InsertReceptionDocumentRequestHandler : IRequestHandler<InsertReceptionDocumentRequest, 
                                                         ApiResponse<Domain.Entities.ReceptionDocument>>
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
        public async Task<ApiResponse<Domain.Entities.ReceptionDocument>> Handle(InsertReceptionDocumentRequest request, 
                                                                       CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));
            
            Domain.Entities.ReceptionDocument result = await _receptionDocumentWriteService.AddAsync(request.ReceptionDocumentData, request.AdminData, cancellationToken);

            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.ReceptionDocument>(result);

        }
    }
}
