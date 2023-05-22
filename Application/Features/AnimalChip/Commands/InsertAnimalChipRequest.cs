using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.InsertAnimalChipRequest.Commands
{
    /// <summary>
    /// Insert AnimalChipOwner request implementation.
    /// </summary>>
    public class InsertAnimalChipRequest : IRequest<ApiResponse<AnimalChip>>
    {
        public AnimalChip AnimalChipData { get; private set; } = null!;
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="animalChipData"></param>
        /// <param name="adminData"></param>
        public InsertAnimalChipRequest(AnimalChip animalChipData, AdminData adminData)
        {
            AnimalChipData = animalChipData;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Insert AnimalChipOwner Request Handler.
    /// </summary>
    public class InsertAnimalChipRequestHandler : IRequestHandler<InsertAnimalChipRequest,
                                                   ApiResponse<AnimalChip>>
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
        public async Task<ApiResponse<AnimalChip>> Handle(InsertAnimalChipRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertAnimalChipRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            AnimalChip result = await _animalChipWrite.AddAsync(request.AnimalChipData, request.AdminData, cancellationToken);

            _logger.LogInformation("InsertAnimalChipRequestHandler --> AddAsync --> End");

            return new ApiResponse<AnimalChip>(result);
        }
    }
}
