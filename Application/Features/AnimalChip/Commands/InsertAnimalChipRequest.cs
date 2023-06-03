using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AnimalChip.Commands
{
    /// <summary>
    /// Insert AnimalChipOwner request implementation.
    /// </summary>>
    public class InsertAnimalChipRequest : IRequest<ApiResponse<Domain.Entities.Shelter.AnimalChip>>
    {
        public Domain.Entities.Shelter.AnimalChip AnimalChipData { get; private set; } = null!;
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="animalChipData"></param>
        /// <param name="adminData"></param>
        public InsertAnimalChipRequest(Domain.Entities.Shelter.AnimalChip animalChipData, AdminData adminData)
        {
            AnimalChipData = animalChipData;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Insert AnimalChipOwner Request Handler.
    /// </summary>
    public class InsertAnimalChipRequestHandler : IRequestHandler<InsertAnimalChipRequest,
        ApiResponse<Domain.Entities.Shelter.AnimalChip>>
    {
        private readonly ILogger<InsertAnimalChipRequestHandler> _logger;
        private readonly IAnimalChipWriteService _animalChipWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="animalChipOwnerWriteService"></param>
        public InsertAnimalChipRequestHandler(ILogger<InsertAnimalChipRequestHandler> logger,
            IAnimalChipWriteService animalChipWrite)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _animalChipWrite = animalChipWrite;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<Domain.Entities.Shelter.AnimalChip>> Handle(InsertAnimalChipRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertAnimalChipRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Shelter.AnimalChip result =
                await _animalChipWrite.AddAsync(request.AnimalChipData, request.AdminData, cancellationToken);

            _logger.LogInformation("InsertAnimalChipRequestHandler --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.Shelter.AnimalChip>(result);
        }
    }
}