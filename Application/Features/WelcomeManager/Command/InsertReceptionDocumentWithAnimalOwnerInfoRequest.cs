using Application.DTOs.WelcomeManager;
using Application.Managers;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Write;
using Application.Service.Implementation.Command;
using Application.Service.Implementation.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.WelcomeManagerFeature.Command
{
    public class InsertReceptionDocumentWithAnimalOwnerInfoRequest : IRequest<ApiResponse<RegisterInformation>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ReceptionDocumentWithAnimalInformation Data { get; set; } = null!;
        public AdminData AdminData { get; set; } = null!;

        public InsertReceptionDocumentWithAnimalOwnerInfoRequest(ReceptionDocumentWithAnimalInformation data, AdminData adminData)
        {
            Data = data;
            AdminData = adminData;
        }
    }

    public class InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler : IRequestHandler<InsertReceptionDocumentWithAnimalOwnerInfoRequest, ApiResponse<RegisterInformation>>
    {
        private readonly ILogger<InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler> _logger;
        private readonly WelcomeManager welcomeManager;

        private IReceptionDocumentWrite _receptionDocumentWrite;
        private IAnimalChipWrite _animalChipWrite;
        private IIndividualProceedingWrite _individualProceedingWrite;

        public InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler(ILogger<InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler> logger,
            IReceptionDocumentWrite receptionDocumentWrite, IAnimalChipWrite animalChipWrite, IIndividualProceedingWrite individualProceedingWrite)
        {
            _logger = logger;
            _receptionDocumentWrite = receptionDocumentWrite;
            _animalChipWrite = animalChipWrite;
            _individualProceedingWrite = individualProceedingWrite;

            welcomeManager = new WelcomeManager(_receptionDocumentWrite, _animalChipWrite, _individualProceedingWrite);
        }
        public async Task<ApiResponse<RegisterInformation>> Handle(InsertReceptionDocumentWithAnimalOwnerInfoRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await welcomeManager.AddAnimalWithOwnerInfo(request.Data, request.AdminData);

            _logger.LogInformation("InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler --> AddAsync --> End");

            return new ApiResponse<RegisterInformation>(result);
        }
    }   
}
