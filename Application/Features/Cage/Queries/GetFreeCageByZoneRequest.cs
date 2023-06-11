﻿using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Cage.Queries
{
    public class GetFreeCageByZoneRequest : IRequest<ApiResponse<Domain.Entities.Shelter.Cage>>
    {
        public int ZoneId { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="zoneId"></param>
        public GetFreeCageByZoneRequest(int zoneId)
        {
            ZoneId = zoneId;
        }
    }

    public class
        GetFreeCageByZoneRequestHandler : IRequestHandler<GetFreeCageByZoneRequest,
            ApiResponse<Domain.Entities.Shelter.Cage>>
    {
        private readonly ILogger<GetFreeCageByZoneRequestHandler> _logger;
        private readonly ICageReadService _cageRead;
        private const string FREE_CAGE_NOT_FOUND = "Free cage not found in zone";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cageRead"></param>
        public GetFreeCageByZoneRequestHandler(ILogger<GetFreeCageByZoneRequestHandler> logger,
            ICageReadService cageRead)
        {
            _logger = logger;
            _cageRead = cageRead;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<Domain.Entities.Shelter.Cage>> Handle(GetFreeCageByZoneRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetFreeCageByZoneRequestHandler --> GetFreeCageByZone --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Shelter.Cage result = await _cageRead.GetFreeCageByZone(request.ZoneId, cancellationToken);

            if (result is null)
            {
                _logger.LogError("GetFreeCageByZoneRequestHandler --> GetFreeCageByZone --> Error");
                throw new NotFoundException(nameof(Domain.Entities.Shelter.Cage), FREE_CAGE_NOT_FOUND);
            }

            return new ApiResponse<Domain.Entities.Shelter.Cage>(result);
        }
    }
}