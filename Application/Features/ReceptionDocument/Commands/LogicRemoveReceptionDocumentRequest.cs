﻿using Application.Service.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ReceptionDocument.Commands
{
    /// <summary>
    /// LogicRemove ReceptionDocument request implementation.
    /// </summary>
    public class LogicRemoveReceptionDocumentRequest : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
        public AdminData AdminData { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public LogicRemoveReceptionDocumentRequest(Guid id, AdminData adminData)
        {
            Id = id;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// LogicRemove ReceptionDocument handler implementation.
    /// </summary>
    public class LogicRemoveReceptionDocumentRequestHandler : IRequestHandler<LogicRemoveReceptionDocumentRequest, ApiResponse<bool>>
    {
        private readonly ILogger<LogicRemoveReceptionDocumentRequestHandler> _logger;
        private readonly IReceptionDocumentWriteService _receptionDocumentWriteService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="receptionDocumentWriteService"></param>
        public LogicRemoveReceptionDocumentRequestHandler(ILogger<LogicRemoveReceptionDocumentRequestHandler> logger, 
            IReceptionDocumentWriteService receptionDocumentWriteService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _receptionDocumentWriteService = Guard.Against.Null(receptionDocumentWriteService);
        }

        ///<inheritdoc />
        public async Task<ApiResponse<bool>> Handle(LogicRemoveReceptionDocumentRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("LogicRemoveReceptionDocumentRequestHandler --> Handle --> Start");

            Guard.Against.Null(request, nameof(request));
            Guard.Against.NullOrEmpty(request.Id, nameof(request.Id));

            bool result = await _receptionDocumentWriteService.LogicRemoveAsync(request.Id, request.AdminData, cancellationToken);

            _logger.LogInformation("LogicRemoveReceptionDocumentRequestHandler --> Handle --> End");

            return new ApiResponse<bool>(result);
        }
    }
}
