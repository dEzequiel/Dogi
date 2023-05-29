using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Person.Commands
{
    public class BanPersonRequest : IRequest<ApiResponse<Domain.Entities.Person>>
    {
        public string PersonId { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="personId"></param>
        public BanPersonRequest(string personId)
        {
            PersonId = personId;
        }
    }

    public class BanPersonRequestHandler : IRequestHandler<BanPersonRequest, ApiResponse<Domain.Entities.Person>>
    {
        private readonly ILogger<BanPersonRequestHandler> Logger;
        private readonly IPersonWriteService PersonWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="personWrite"></param>
        public BanPersonRequestHandler(ILogger<BanPersonRequestHandler> logger, IPersonWriteService personWrite)
        {
            Logger = logger;
            PersonWrite = personWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.Person>> Handle(BanPersonRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("BanPersonRequest --> BanAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Person result = await PersonWrite.BanAsync(request.PersonId);

            Logger.LogInformation("BanPersonRequest --> BanAsync --> End");

            return new ApiResponse<Domain.Entities.Person>(result);
        }
    }
}
