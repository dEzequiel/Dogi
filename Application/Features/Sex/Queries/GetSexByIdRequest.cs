using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Sex.Queries
{
    /// <summary>
    /// Get sex by identifier request implementation.
    /// </summary>
    public class GetSexByIdRequest : IRequest<ApiResponse<Domain.Entities.Shelter.Sex>>
    {
        public int Id { get; private set; }

        public GetSexByIdRequest(int id)
        {
            Id = Guard.Against.Null(id, nameof(id));
        }
    }

    /// <summary>
    /// Get sex by identifier request handler implementation.
    /// </summary>
    public class GetSexByIdRequestHandler : IRequestHandler<GetSexByIdRequest, ApiResponse<Domain.Entities.Shelter.Sex>>
    {
        private readonly ILogger<GetSexByIdRequestHandler> Logger;
        private readonly ISexReadService SexRead;
        private const string SEX_NOT_FOUND = "Sex with id {0} not found.";

        public GetSexByIdRequestHandler(ILogger<GetSexByIdRequestHandler> logger, ISexReadService sexRead)
        {
            Logger = Guard.Against.Null(logger, nameof(logger));
            SexRead = Guard.Against.Null(sexRead, nameof(sexRead));
        }

        ///<inheritdoc />
        public async Task<ApiResponse<Domain.Entities.Shelter.Sex>> Handle(GetSexByIdRequest request,
            CancellationToken cancellationToken)
        {
            Logger.LogInformation($"GetSexByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Entities.Shelter.Sex? result = await SexRead.GetByIdAsync(request.Id);

            if (result is null)
            {
                Logger.LogInformation($"GetSexByIdRequestHandler --> GetByIdAsync({request.Id}) --> Not Found");

                return new ApiResponse<Domain.Entities.Shelter.Sex>()
                {
                    Succeeded = false,
                    Message = string.Format(SEX_NOT_FOUND, request.Id),
                    Data = null
                };
            }

            Logger.LogInformation($"GetSexByIdRequestHandler --> GetByIdAsync --> End");

            return new ApiResponse<Domain.Entities.Shelter.Sex>(result);
        }
    }
}