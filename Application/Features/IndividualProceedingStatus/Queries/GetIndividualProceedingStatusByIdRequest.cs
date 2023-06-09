﻿using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.IndividualProceedingStatus.Queries
{
    /// <summary>
    /// Get IndividualProceedingStatus by identifier request implementation.
    /// </summary>
    public class
        GetIndividualProceedingStatusByIdRequest : IRequest<
            ApiResponse<Domain.Entities.Shelter.IndividualProceedingStatus>>
    {
        public int Id { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public GetIndividualProceedingStatusByIdRequest(int id)
        {
            Id = id;
        }
    }

    public class GetIndividualProceedingStatusByIdRequestHandler : IRequestHandler<
        GetIndividualProceedingStatusByIdRequest,
        ApiResponse<Domain.Entities.Shelter.IndividualProceedingStatus>>
    {
        private readonly ILogger<GetIndividualProceedingStatusByIdRequestHandler> Logger;
        private readonly IIndividualProceedingStatusReadService IndividualProceedingStatusRead;

        private const string INDIVIDUAL_PROCEEDING_STATUS_NOT_FOUND =
            "IndividualProceedingStatus with id {0} not found.";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="individualProceedingStatusRead"></param>
        public GetIndividualProceedingStatusByIdRequestHandler(
            ILogger<GetIndividualProceedingStatusByIdRequestHandler> logger,
            IIndividualProceedingStatusReadService individualProceedingStatusRead)
        {
            Logger = logger;
            IndividualProceedingStatusRead = individualProceedingStatusRead;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<Domain.Entities.Shelter.IndividualProceedingStatus>> Handle(
            GetIndividualProceedingStatusByIdRequest request,
            CancellationToken cancellationToken)
        {
            Logger.LogInformation(
                $"GetIndividualProceedingStatusByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Shelter.IndividualProceedingStatus? result =
                await IndividualProceedingStatusRead.GetByIdAsync(request.Id);

            if (result is null)
            {
                Logger.LogInformation(
                    $"GetIndividualProceedingStatusByIdRequestHandler --> GetByIdAsync({request.Id}) --> Not Found");

                return new ApiResponse<Domain.Entities.Shelter.IndividualProceedingStatus>()
                {
                    Succeeded = false,
                    Message = string.Format(INDIVIDUAL_PROCEEDING_STATUS_NOT_FOUND, request.Id),
                    Data = null
                };
            }

            Logger.LogInformation($"GetIndividualProceedingStatusByIdRequestHandler --> GetByIdAsync --> End");

            return new ApiResponse<Domain.Entities.Shelter.IndividualProceedingStatus>(result);
        }
    }
}