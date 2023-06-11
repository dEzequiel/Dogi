using Application.DTOs.VeterinaryManager;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VaccinationCardVaccine.Commands
{
    /// <summary>
    /// Vaccine exiting vaccination record request implementation.
    /// </summary>
    public class VaccinationCardVaccineVaccineRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>>
    {
        public Guid VaccinationCardId { get; private set; }
        public VaccinesToComplish VaccinesIds { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccineId"></param>
        /// <param name="adminData"></param>
        public VaccinationCardVaccineVaccineRequest(Guid vaccinationCardId, VaccinesToComplish vaccinesIds, AdminData adminData)
        {
            VaccinationCardId = vaccinationCardId;
            VaccinesIds = vaccinesIds;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Vaccine exiting vaccination record handler implementation.
    /// </summary>
    public class VaccinationCardVaccineVaccineRequestHandler : IRequestHandler<VaccinationCardVaccineVaccineRequest, ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>>
    {
        private readonly ILogger<VaccinationCardVaccineVaccineRequestHandler> Logger;
        private readonly IVaccinationCardVaccineWriteService VaccinationCardWrite;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="vaccinationCardWrite"></param>
        public VaccinationCardVaccineVaccineRequestHandler(ILogger<VaccinationCardVaccineVaccineRequestHandler> logger,
                                                                          IVaccinationCardVaccineWriteService vaccinationCardWrite)
        {
            Logger = logger;
            VaccinationCardWrite = vaccinationCardWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>> Handle(VaccinationCardVaccineVaccineRequest request,
                                                                                      CancellationToken cancellationToken)
        {
            Logger.LogInformation("VaccineExistingVaccinationCardVaccineVaccineRequestHandler --> VaccineAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await VaccinationCardWrite.VaccineAsync(request.VaccinationCardId, request.VaccinesIds, request.AdminData, cancellationToken);

            Logger.LogInformation("VaccineExistingVaccinationCardVaccineVaccineRequestHandler --> VaccineAsync --> Start");

            return new ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>(result);
        }
    }
}
