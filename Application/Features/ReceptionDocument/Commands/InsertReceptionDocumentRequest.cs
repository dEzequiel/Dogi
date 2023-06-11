using Application.Service.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ReceptionDocument.Commands
{
    /// <summary>
    /// Insert ReceptionDocument request implementation.
    /// </summary>
    public class InsertReceptionDocumentRequest : IRequest<ApiResponse<Domain.Entities.Shelter.ReceptionDocument>>
    {
        public Domain.Entities.Shelter.ReceptionDocument ReceptionDocumentData { get; private set; } = null!;
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="receptionDocumentData"></param>
        /// <param name="adminData"></param>
        public InsertReceptionDocumentRequest(Domain.Entities.Shelter.ReceptionDocument receptionDocumentData,
            AdminData adminData)
        {
            ReceptionDocumentData = receptionDocumentData;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Insert ReceptionDocument handler implementation.
    /// </summary>
    public class InsertReceptionDocumentRequestHandler : IRequestHandler<InsertReceptionDocumentRequest,
        ApiResponse<Domain.Entities.Shelter.ReceptionDocument>>
    {
        private readonly ILogger<InsertReceptionDocumentRequestHandler> _logger;
        private readonly IReceptionDocumentWriteService _receptionDocumentWriteService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentWriteService"></param>
        public InsertReceptionDocumentRequestHandler(ILogger<InsertReceptionDocumentRequestHandler> logger,
            IReceptionDocumentWriteService receptionDocumentWriteService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _receptionDocumentWriteService = Guard.Against.Null(receptionDocumentWriteService);
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<Domain.Entities.Shelter.ReceptionDocument>> Handle(
            InsertReceptionDocumentRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Shelter.ReceptionDocument result =
                await _receptionDocumentWriteService.AddAsync(request.ReceptionDocumentData, request.AdminData,
                    cancellationToken);

            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.Shelter.ReceptionDocument>(result);
        }
    }
}