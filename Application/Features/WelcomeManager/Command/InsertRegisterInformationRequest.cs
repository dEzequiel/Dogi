using Application.DTOs.WelcomeManager;
using Application.Managers;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.WelcomeManagerFeature.Command
{
    public class InsertRegisterInformationRequest : IRequest<ApiResponse<RegisterInformation>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RegisterInformation Data { get; set; } = null!;
        public AdminData AdminData { get; set; } = null!;

        public InsertRegisterInformationRequest(RegisterInformation data, AdminData adminData)
        {
            Data = data;
            AdminData = adminData;
        }
    }

    public class InsertRegisterInformationRequestHandler : IRequestHandler<InsertRegisterInformationRequest, ApiResponse<RegisterInformation>>
    {
        private readonly ILogger<InsertRegisterInformationRequestHandler> _logger;
        private readonly IWelcomeManager _welcomeManager;

        public InsertRegisterInformationRequestHandler(ILogger<InsertRegisterInformationRequestHandler> logger, IWelcomeManager welcomeManager)
        {
            _logger = logger;
            _welcomeManager = welcomeManager;
        }
        public async Task<ApiResponse<RegisterInformation>> Handle(InsertRegisterInformationRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await _welcomeManager.RegisterAnimal(request.Data, request.AdminData);

            _logger.LogInformation("InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler --> AddAsync --> End");

            return new ApiResponse<RegisterInformation>(result);
        }
    }
}
