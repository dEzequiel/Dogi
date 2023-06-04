using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.PersonBannedInformation.Commands
{
    public class
        InsertPersonBannedInformationRequest : IRequest<ApiResponse<Domain.Entities.Shelter.PersonBannedInformation>>
    {
        public Domain.Entities.Shelter.PersonBannedInformation PersonBannedInformationData { get; private set; }
        public AdminData AdminData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="personBannedInformationData"></param>
        public InsertPersonBannedInformationRequest(
            Domain.Entities.Shelter.PersonBannedInformation personBannedInformationData, AdminData adminData)
        {
            PersonBannedInformationData = personBannedInformationData;
            AdminData = adminData;
        }
    }

    public class InsertPersonBannedInformationRequestHandler : IRequestHandler<InsertPersonBannedInformationRequest,
        ApiResponse<Domain.Entities.Shelter.PersonBannedInformation>>
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
        public async Task<ApiResponse<Domain.Entities.Shelter.PersonBannedInformation>> Handle(
            InsertPersonBannedInformationRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("InsertPersonBannedInformationRequest --> AddAsync --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Shelter.PersonBannedInformation result = await PersonBannedInformationWrite.AddAsync(
                request.PersonBannedInformationData,
                request.AdminData,
                cancellationToken);

            Logger.LogInformation("InsertPersonBannedInformationRequest --> AddAsync --> End");

            return new ApiResponse<Domain.Entities.Shelter.PersonBannedInformation>(result);
        }
    }
}