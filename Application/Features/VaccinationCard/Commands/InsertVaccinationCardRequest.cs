using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VaccinationCard.Commands
{
    public class InsertVaccinationCardRequest : IRequest<ApiResponse<Domain.Entities.VaccinationCard>>
    {
        public Domain.Entities.VaccinationCard VaccinationCardData { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccinationCardData"></param>
        /// <param name="adminData"></param>
        public InsertVaccinationCardRequest(Domain.Entities.VaccinationCard vaccinationCardData, AdminData adminData)
        {
            VaccinationCardData = vaccinationCardData;
            AdminData = adminData;
        }
    }

    public class InsertVaccinationCardRequestHandler : IRequestHandler<InsertVaccinationCardRequest,
                                                        ApiResponse<Domain.Entities.VaccinationCard>>
    {
        private readonly ILogger<InsertVaccinationCardRequestHandler> Logger;
        private readonly IVaccinationCardWriteService VaccinationCardWrite;

        /// <summary>///Constructor
        public InsertVaccinationCardRequestHandler(ILogger<InsertVaccinationCardRequestHandler> logger,
                                                   IVaccinationCardWriteService vaccinationCardWrite)
        {
            Logger = logger;
            VaccinationCardWrite = vaccinationCardWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.VaccinationCard>> Handle(InsertVaccinationCardRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertVaccinationCardRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.VaccinationCard result = await VaccinationCardWrite.AddAsync(request.VaccinationCardData, request.AdminData);

            Logger.LogInformation("InsertVaccinationCardRequestHandler --> AddAsync --> Start");

            return new ApiResponse<Domain.Entities.VaccinationCard>(result);
        }
    }
}
