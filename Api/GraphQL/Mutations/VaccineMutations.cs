using Application.Features.Vaccine.Commands;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;

namespace Api.GraphQL.Mutations
{
    public class VaccineMutations
    {
        private readonly IMediator Mediator;
        private readonly ILogger<VaccineMutations> Logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public VaccineMutations(IMediator mediator, ILogger<VaccineMutations> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        public async Task<IEnumerable<Vaccine>> AddVaccine([Service] ISender Mediator, IEnumerable<Vaccine> input)
        {
            Logger.LogInformation("VaccineMutations --> AddVaccine --> Start");

            var result = await Mediator.Send(new InsertVaccineRequest(input));

            if (result.Data is null)
            {
                Logger.LogInformation("VaccineMutations --> AddVaccine --> Error");
                throw new DogiException(result.Message);
            }

            Logger.LogInformation("VaccineMutations --> AddVaccine --> End");

            return result.Data;
        }
    }
}
