using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.VaccinationCardVaccine.Commands
{
    /// <summary>
    /// Insert CollectionVaccinationCardVaccineVaccines request  implementation.
    /// </summary>
    public class InsertCollectionVaccinationCardVaccineVaccinesRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>>
    {
        public Guid VaccinationCardId { get; private set; }
        public IEnumerable<Guid> VaccineIds { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccinationCardId"></param>
        /// <param name="vaccineIds"></param>
        /// <param name="adminData"></param>
        public InsertCollectionVaccinationCardVaccineVaccinesRequest(Guid vaccinationCardId, IEnumerable<Guid> vaccineIds, AdminData adminData)
        {
            VaccinationCardId = vaccinationCardId;
            VaccineIds = vaccineIds;
            AdminData = adminData;
        }
    }

    /// <summary>
    /// Insert CollectionVaccinationCardVaccineVaccines request handler implementation.
    /// </summary>
    public class InsertCollectionVaccinationCardVaccineVaccinesRequestHandler : IRequestHandler<InsertCollectionVaccinationCardVaccineVaccinesRequest,
        ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>>
    {
        private readonly ILogger<InsertCollectionVaccinationCardVaccineVaccinesRequestHandler> Logger;
        private readonly IVaccinationCardVaccineWriteService VaccinationCardVaccineWrite;

        public InsertCollectionVaccinationCardVaccineVaccinesRequestHandler(
            ILogger<InsertCollectionVaccinationCardVaccineVaccinesRequestHandler> logger,
            IVaccinationCardVaccineWriteService vaccinationCardVaccineWrite)
        {
            Logger = logger;
            VaccinationCardVaccineWrite = vaccinationCardVaccineWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>> Handle(InsertCollectionVaccinationCardVaccineVaccinesRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertCollectionVaccinationCardVaccineVaccinesRequestHandler --> AddRangeAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            var result = await VaccinationCardVaccineWrite.AddRangeAsync(request.VaccinationCardId, request.VaccineIds, request.AdminData);

            Logger.LogInformation("InsertCollectionVaccinationCardVaccineVaccinesRequestHandler --> AddRangeAsync --> End");

            return new ApiResponse<IEnumerable<Domain.Entities.VaccinationCardVaccine>>(result);
        }
    }
}
