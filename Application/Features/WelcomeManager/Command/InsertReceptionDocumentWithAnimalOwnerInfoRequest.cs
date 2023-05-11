using Application.DTOs.WelcomeManager;
using Application.Managers;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Write;
using Application.Service.Implementation.Command;
using Application.Service.Implementation.Write;
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

        private IAnimalChipOwnerWrite _animalChipOwnerWrite;
        private IReceptionDocumentWrite _receptionDocumentWrite;

        public InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler(ILogger<InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler> logger, IAnimalChipOwnerWrite animalChipOwnerWrite,
            IReceptionDocumentWrite receptionDocumentWrite)
        {
            _logger = logger;
            _animalChipOwnerWrite = animalChipOwnerWrite;
            _receptionDocumentWrite = receptionDocumentWrite;
            welcomeManager = new WelcomeManager(_animalChipOwnerWrite, _receptionDocumentWrite);
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
