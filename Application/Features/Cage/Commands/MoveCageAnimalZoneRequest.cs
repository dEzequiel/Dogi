using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Cage.Commands
{
    public class MoveCageAnimalZoneRequest : IRequest<ApiResponse<Domain.Entities.Cage>>
    {
        public Guid CageId { get; private set; }
        public int AnimalZoneId { get; private set; }
        public AdminData Admin { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cageId"></param>
        /// <param name="animalZoneId"></param>
        /// <param name="adminData"></param>
        public MoveCageAnimalZoneRequest(Guid cageId, int animalZoneId, AdminData adminData)
        {
            CageId = cageId;
            AnimalZoneId = animalZoneId;
            Admin = adminData;
        }
    }

    public class MoveCageAnimalZoneRequestHandler : IRequestHandler<MoveCageAnimalZoneRequest,
        ApiResponse<Domain.Entities.Cage>>
    {
        private readonly ILogger<MoveCageAnimalZoneRequestHandler> Logger;
        private readonly ICageWriteService CageWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cageWrite"></param>
        public MoveCageAnimalZoneRequestHandler(ILogger<MoveCageAnimalZoneRequestHandler> logger, ICageWriteService cageWrite)
        {
            Logger = logger;
            CageWrite = cageWrite;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<Domain.Entities.Cage>> Handle(MoveCageAnimalZoneRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("MoveCageAnimalZoneRequestHandler --> UpdateAnimalZone --> Start");

            Guard.Against.Null(request, nameof(request));
            Guard.Against.NullOrEmpty(request.CageId, nameof(request.CageId));
            Guard.Against.Null(request.AnimalZoneId, nameof(request.AnimalZoneId));

            var result = await CageWrite.MoveCageAnimalZoneAsync(request.CageId, request.AnimalZoneId, request.Admin, cancellationToken);

            Logger.LogInformation("MoveCageAnimalZoneRequestHandler --> UpdateAnimalZone --> End");

            return new ApiResponse<Domain.Entities.Cage>(result);

        }
    }
}
