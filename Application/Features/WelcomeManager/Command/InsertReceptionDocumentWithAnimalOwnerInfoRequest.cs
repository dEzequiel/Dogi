using Application.DTOs.WelcomeManager;
using Application.Managers;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.WelcomeManagerFeature.Command
{
    public class InsertReceptionDocumentWithAnimalOwnerInfoRequest : IRequest<ApiResponse<ReceptionDocumentWithAnimalOwnerInfo>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Domain.Entities.ReceptionDocument ReceptionDocument { get; set; } = null!;
        public AnimalChipOwner? AnimalChipOwner { get; set; }
        public AdminData AdminData { get; set; } = null!;

        public InsertReceptionDocumentWithAnimalOwnerInfoRequest(Domain.Entities.ReceptionDocument receptionDocument, AnimalChipOwner? animalChipOwner, AdminData adminData)
        {
            ReceptionDocument = receptionDocument;
            AnimalChipOwner = animalChipOwner;
            AdminData = adminData;
        }
    }

    public class InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler : IRequestHandler<InsertReceptionDocumentWithAnimalOwnerInfoRequest, ApiResponse<ReceptionDocumentWithAnimalOwnerInfo>>
    {
        private readonly ILogger<InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler> _logger;
        private readonly WelcomeManager welcomeManager;

        public InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler(ILogger<InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler> logger)
        {
            _logger = logger;
            welcomeManager = new WelcomeManager();
        }
        public async Task<ApiResponse<ReceptionDocumentWithAnimalOwnerInfo>> Handle(InsertReceptionDocumentWithAnimalOwnerInfoRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await welcomeManager.AddAnimalWithOwnerInfo(request.ReceptionDocument, request.AnimalChipOwner, request.AdminData);

            _logger.LogInformation("InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler --> AddAsync --> End");

            return new ApiResponse<ReceptionDocumentWithAnimalOwnerInfo>(result);
        }
    }   
}
