using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VaccinationCardVaccine.Commands
{
    public class InsertVaccinationCardVaccineVaccineRequest : IRequest<ApiResponse<Domain.Entities.VaccinationCardVaccine>>
    {
        public Domain.Entities.VaccinationCardVaccine Vaccine { get; set; }
        public AdminData AdminData { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccine"></param>
        /// <param name="adminData"></param>
        public InsertVaccinationCardVaccineVaccineRequest(Domain.Entities.VaccinationCardVaccine vaccine, AdminData adminData)
        {
            Vaccine = vaccine;
            AdminData = adminData;
        }
    }

    public class InsertVaccineCardVaccineVaccineRequestHandler : IRequestHandler<InsertVaccinationCardVaccineVaccineRequest,
                                                                    ApiResponse<Domain.Entities.VaccinationCardVaccine>>
    {
        private readonly ILogger<InsertVaccineCardVaccineVaccineRequestHandler> Logger;
        private readonly IVaccinationCardVaccineWriteService VaccinationCardVaccineWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="vaccinationCardVaccineWrite"></param>
        public InsertVaccineCardVaccineVaccineRequestHandler(ILogger<InsertVaccineCardVaccineVaccineRequestHandler> logger,
                                                             IVaccinationCardVaccineWriteService vaccinationCardVaccineWrite)
        {
            Logger = logger;
            VaccinationCardVaccineWrite = vaccinationCardVaccineWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.VaccinationCardVaccine>> Handle(InsertVaccinationCardVaccineVaccineRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertVaccineCardVaccineVaccineRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.VaccinationCardVaccine result = await VaccinationCardVaccineWrite.AddAsync(request.Vaccine, request.AdminData);

            Logger.LogInformation("InsertVaccineCardVaccineVaccineRequestHandler --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.VaccinationCardVaccine>(result);
        }
    }
}
