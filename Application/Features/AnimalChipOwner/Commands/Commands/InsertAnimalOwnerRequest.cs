using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AnimalChipOwnerFeature.Commands.Commands
{
    /// <summary>
    /// Insert AnimalChipOwner request implementation.
    /// </summary>>
    public class InsertAnimalOwnerRequest : IRequest<ApiResponse<AnimalChipOwner>>
    {
        public AnimalChipOwner AnimalChipOwnerData { get; private set; } = null!;
        public AdminData AdminData { get; private set; } = null!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="animalChipData"></param>
        /// <param name="adminData"></param>
        public InsertAnimalOwnerRequest(AnimalChipOwner animalChipData, AdminData adminData)
        {
            AnimalChipOwnerData = animalChipData;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Insert AnimalChipOwner Request Handler.
    /// </summary>
    public class InsertAnimalOwnerRequestHandler : IRequestHandler<InsertAnimalOwnerRequest,
                                                   ApiResponse<AnimalChipOwner>>
    {
        private readonly ILogger<InsertAnimalOwnerRequestHandler> _logger;
        private readonly IAnimalChipOwnerWrite _animalChipOwnerWriteService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="animalChipOwnerWriteService"></param>
        public InsertAnimalOwnerRequestHandler(ILogger<InsertAnimalOwnerRequestHandler> logger, 
            IAnimalChipOwnerWrite animalChipOwnerWriteService)
        {
            _logger = Guard.Against.Null(logger, nameof(logger));
            _animalChipOwnerWriteService = animalChipOwnerWriteService;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<AnimalChipOwner>> Handle(InsertAnimalOwnerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertAnimalOwnerRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            AnimalChipOwner result = await _animalChipOwnerWriteService.AddAsync(request.AnimalChipOwnerData, request.AdminData, cancellationToken);

            _logger.LogInformation("InsertReceptionDocumentRequestHandler --> AddAsync --> End");

            return new ApiResponse<AnimalChipOwner>(result);
        }
    }
}
