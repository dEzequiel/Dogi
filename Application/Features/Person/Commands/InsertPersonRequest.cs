using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Person.Commands
{
    public class InsertPersonRequest : IRequest<ApiResponse<Domain.Entities.Person>>
    {
        public Domain.Entities.Person PersonData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="personData"></param>
        public InsertPersonRequest(Domain.Entities.Person personData)
        {
            PersonData = personData;
        }
    }

    public class InsertPersonRequestHandler : IRequestHandler<InsertPersonRequest, ApiResponse<Domain.Entities.Person>>
    {
        private readonly ILogger<InsertPersonRequestHandler> Logger;
        private readonly IPersonWriteService PersonWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="personWrite"></param>
        public InsertPersonRequestHandler(ILogger<InsertPersonRequestHandler> logger, IPersonWriteService personWrite)
        {
            Logger = logger;
            PersonWrite = personWrite;
        }

        public async Task<ApiResponse<Domain.Entities.Person>> Handle(InsertPersonRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertPersonRequest --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Person result = await PersonWrite.AddAsync(request.PersonData);

            Logger.LogInformation("InsertPersonRequest --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.Person>(result);

        }
    }
}
