using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Vaccine.Commands
{
    /// <summary>
    /// Insert Vaccine request implementation.
    /// </summary>
    public class InsertVaccineRequest : IRequest<ApiResponse<IEnumerable<Domain.Entities.Vaccine>>>
    {
        public IEnumerable<Domain.Entities.Vaccine> Vaccines { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaccine"></param>
        public InsertVaccineRequest(IEnumerable<Domain.Entities.Vaccine> vaccines)
        {
            Vaccines = vaccines;
        }
    }

    /// <summary>
    /// Insert Vaccine handler implementation.
    /// </summary>
    public class InsertVaccineRequestHandler : IRequestHandler<InsertVaccineRequest, ApiResponse<IEnumerable<Domain.Entities.Vaccine>>>
    {
        private readonly ILogger<InsertVaccineRequestHandler> Logger;
        private readonly IVaccineWriteService VaccineWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="vaccineWrite"></param>
        public InsertVaccineRequestHandler(ILogger<InsertVaccineRequestHandler> logger, IVaccineWriteService vaccineWrite)
        {
            Logger = logger;
            VaccineWrite = vaccineWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<IEnumerable<Domain.Entities.Vaccine>>> Handle(InsertVaccineRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertVaccineRequestHandler --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            IEnumerable<Domain.Entities.Vaccine> result = await VaccineWrite.AddAsync(request.Vaccines, cancellationToken);

            Logger.LogInformation("InsertVaccineRequestHandler --> AddAsync --> End");

            return new ApiResponse<IEnumerable<Domain.Entities.Vaccine>>(result);
        }
    }
}
