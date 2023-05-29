using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.PersonBannedInformation.Commands
{
    public class InsertPersonBannedInformationRequest : IRequest<ApiResponse<Domain.Entities.PersonBannedInformation>>
    {
        public Domain.Entities.PersonBannedInformation PersonBannedInformationData { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="personBannedInformationData"></param>
        public InsertPersonBannedInformationRequest(Domain.Entities.PersonBannedInformation personBannedInformationData, AdminData adminData)
        {
            PersonBannedInformationData = personBannedInformationData;
            AdminData = adminData;
        }
    }

    public class InsertPersonBannedInformationRequestHandler : IRequestHandler<InsertPersonBannedInformationRequest, ApiResponse<Domain.Entities.PersonBannedInformation>>
    {
        private readonly ILogger<InsertPersonBannedInformationRequestHandler> Logger;
        private readonly IPersonBannedInformationWriteService PersonBannedInformationWrite;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="personBannedInformationWrite"></param>
        public InsertPersonBannedInformationRequestHandler(ILogger<InsertPersonBannedInformationRequestHandler> logger,
            IPersonBannedInformationWriteService personBannedInformationWrite)
        {
            Logger = logger;
            PersonBannedInformationWrite = personBannedInformationWrite;
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.PersonBannedInformation>> Handle(InsertPersonBannedInformationRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertPersonBannedInformationRequest --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.PersonBannedInformation result = await PersonBannedInformationWrite.AddAsync(request.PersonBannedInformationData,
                                                                                                         request.AdminData,
                                                                                                         cancellationToken);

            Logger.LogInformation("InsertPersonBannedInformationRequest --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.PersonBannedInformation>(result);
        }
    }
}
