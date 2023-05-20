using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.IndividualPro.Commands
{
    public class InsertIndividualProceedingRequest : IRequest<ApiResponse<IndividualProceeding>>
    {
        public IndividualProceeding IndividualProceedingData { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="individualProceedingData"></param>
        /// <param name="adminData"></param>
        public InsertIndividualProceedingRequest(IndividualProceeding individualProceedingData, AdminData adminData)
        {
            IndividualProceedingData = individualProceedingData;
            AdminData = adminData;
        }
    }

    public class InsertIndividualProceedingRequestHandler : IRequestHandler<InsertIndividualProceedingRequest,
                                                         ApiResponse<IndividualProceeding>>
    {
        private readonly ILogger<InsertIndividualProceedingRequestHandler> _logger;
        private readonly IIndividualProceedingWrite _individualProceedingWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="individualProceedingWrite"></param>
        public InsertIndividualProceedingRequestHandler(ILogger<InsertIndividualProceedingRequestHandler> logger, IIndividualProceedingWrite individualProceedingWrite)
        {
            _logger = logger;
            _individualProceedingWrite = individualProceedingWrite;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<IndividualProceeding>> Handle(InsertIndividualProceedingRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertIndividualProceedingRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            IndividualProceeding result = await _individualProceedingWrite.AddAsync(request.IndividualProceedingData, request.AdminData);

            return new ApiResponse<IndividualProceeding>(result);
        }
    }
}
