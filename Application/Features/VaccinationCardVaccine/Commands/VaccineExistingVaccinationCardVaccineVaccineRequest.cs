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
    public class VaccineExistingVaccinationCardVaccineVaccineRequest : IRequest<ApiResponse<Domain.Entities.VaccinationCardVaccine>>
    {
        public Guid VaccinationCardId { get; private set; }
        public Guid VaccineId { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccineId"></param>
        /// <param name="adminData"></param>
        public VaccineExistingVaccinationCardVaccineVaccineRequest(Guid vaccinationCardId, Guid vaccineId, AdminData adminData)
        {
            VaccinationCardId = vaccinationCardId;
            VaccineId = vaccineId;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Vaccine exiting vaccination record handler implementation.
    /// </summary>
    public class VaccineExistingVaccinationCardVaccineVaccineRequestHandler : IRequestHandler<VaccineExistingVaccinationCardVaccineVaccineRequest, ApiResponse<Domain.Entities.VaccinationCardVaccine>>
    {
        private readonly ILogger<VaccineExistingVaccinationCardVaccineVaccineRequestHandler> Logger;
        private readonly IVaccinationCardVaccineWriteService VaccinationCardWrite;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="vaccinationCardWrite"></param>
        public VaccineExistingVaccinationCardVaccineVaccineRequestHandler(ILogger<VaccineExistingVaccinationCardVaccineVaccineRequestHandler> logger,
                                                                          IVaccinationCardVaccineWriteService vaccinationCardWrite)
        {
            Logger = logger;
            VaccinationCardWrite = vaccinationCardWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.VaccinationCardVaccine>> Handle(VaccineExistingVaccinationCardVaccineVaccineRequest request,
                                                                                      CancellationToken cancellationToken)
        {
            Logger.LogInformation("VaccineExistingVaccinationCardVaccineVaccineRequestHandler --> VaccineAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.VaccinationCardVaccine result = await VaccinationCardWrite.VaccineAsync(request.VaccinationCardId, request.VaccineId, request.AdminData);

            Logger.LogInformation("VaccineExistingVaccinationCardVaccineVaccineRequestHandler --> VaccineAsync --> Start");

            return new ApiResponse<Domain.Entities.VaccinationCardVaccine>(result);
        }
    }
}
