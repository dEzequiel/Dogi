using Application.DTOs.VeterinaryManager;
using Application.Managers.Abstraction;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VeterinaryManager.Command
{
    public class AssignVaccineRequest : IRequest<ApiResponse<IndividualProceedingWithVaccinationCard>>
    {
        public Guid VaccinationCardI { get; private set; }
        public Guid VaccineId { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccinationCardI"></param>
        /// <param name="vaccineId"></param>
        /// <param name="adminData"></param>
        public AssignVaccineRequest(Guid vaccinationCardI, Guid vaccineId, AdminData adminData)
        {
            VaccinationCardI = vaccinationCardI;
            VaccineId = vaccineId;
            AdminData = adminData;
        }
    }

    public class AssignVaccineRequestHandler : IRequestHandler<AssignVaccineRequest, ApiResponse<IndividualProceedingWithVaccinationCard>>
    {
        private readonly ILogger<AssignVaccineRequestHandler> Logger;
        private readonly IVeterinaryManager VeteriyaryManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="veteriyaryManager"></param>
        public AssignVaccineRequestHandler(ILogger<AssignVaccineRequestHandler> logger, IVeterinaryManager veteriyaryManager)
        {
            Logger = logger;
            VeteriyaryManager = veteriyaryManager;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IndividualProceedingWithVaccinationCard>> Handle(AssignVaccineRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("AssignVaccineRequestHandler --> AssignPendingVaccine --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await VeteriyaryManager.AssignPendingVaccine(request.VaccinationCardI, request.VaccineId, request.AdminData, cancellationToken);

            Logger.LogInformation("AssignVaccineRequestHandler --> AssignPendingVaccine --> End");

            return new ApiResponse<IndividualProceedingWithVaccinationCard>(result);
        }
    }
}
