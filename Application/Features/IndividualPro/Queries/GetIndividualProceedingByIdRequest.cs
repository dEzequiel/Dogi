using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.IndividualPro.Queries
{
    /// <summary>
    /// Get IndividualProceeding by identifier request implementation.
    /// </summary>
    public class GetIndividualProceedingByIdRequest : IRequest<ApiResponse<Domain.Entities.IndividualProceeding>>
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public GetIndividualProceedingByIdRequest(Guid id) => this.Id = id;
    }

    public class GetIndividualProceedingByIdRequestHandler : IRequestHandler<GetIndividualProceedingByIdRequest,
        ApiResponse<Domain.Entities.IndividualProceeding>>
    {
        private readonly ILogger<GetIndividualProceedingByIdRequestHandler> Logger;
        private readonly IIndividualProceedingReadService IndividualProceedingReadService;
        private const string INDIVIDUAL_PROCEEDING_NOT_FOUND = "IndividualProceeding with id {0} not found.";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="individualProceedingReadService"></param>
        public GetIndividualProceedingByIdRequestHandler(ILogger<GetIndividualProceedingByIdRequestHandler> logger,
                                                         IIndividualProceedingReadService individualProceedingReadService)
        {
            Logger = Guard.Against.Null(logger);
            IndividualProceedingReadService = Guard.Against.Null(individualProceedingReadService);
        }

        public async Task<ApiResponse<IndividualProceeding>> Handle(GetIndividualProceedingByIdRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"GetIndividualProceedingByIdRequestHandler --> GetAsync({request.Id}) -> Start");

            Guard.Against.Null(request);

            IndividualProceeding? result = await IndividualProceedingReadService.GetByIdAsync(request.Id, cancellationToken);

            if (result is null)
            {
                Logger.LogInformation($"GetIndividualProceedingByIdRequestHandler --> GetByIdAsync({request.Id}) --> Not Found");

                return new ApiResponse<IndividualProceeding>()
                {
                    Succeeded = false,
                    Message = string.Format(INDIVIDUAL_PROCEEDING_NOT_FOUND, request.Id),
                    Data = null
                };
            }

            return new ApiResponse<IndividualProceeding>(result);
        }
    }
}
