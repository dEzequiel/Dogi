using Application.Features.ReceptionDocument.Commands;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Shelter;
using MediatR;

namespace Api.GraphQL.Mutations
{
    /// <summary>
    /// ReceptionDocument entity public mutations.
    /// </summary>
    public class ReceptionDocumentMutations
    {
        public ILogger<ReceptionDocumentMutations> Logger { get; set; } = null!;
        public IMediator Mediator { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_mediator"></param>
        /// <param name="_logger"></param>
        public ReceptionDocumentMutations(IMediator _mediator, ILogger<ReceptionDocumentMutations> _logger)
        {
            Mediator = _mediator;
            Logger = _logger;
        }

        public ReceptionDocumentMutations()
        {
        }


        public async Task<ReceptionDocument> AddReceptionDocumentAsync([Service] ISender Mediator,
            ReceptionDocument input)
        {
            Logger.LogInformation("ReceptionDocumentMutations --> AddReceptionDocumentAsync --> Start");

            var result = await Mediator.Send(new InsertReceptionDocumentRequest(input, GetAdminData()));

            if (result.Data is null)
            {
                Logger.LogInformation("ReceptionDocumentMutations --> AddReceptionDocumentAsync --> Error");

                throw new DogiException(result.Message);
            }

            Logger.LogInformation("ReceptionDocumentMutations --> AddReceptionDocumentAsync --> End");


            return result.Data;
        }

        public async Task<bool> MarkReceptionDocumentAsRemovedAsync([Service] ISender _mediator, Guid idToDelete)
        {
            var result = await _mediator.Send(new LogicRemoveReceptionDocumentRequest(idToDelete, GetAdminData()));

            if (!result.Succeeded)
            {
                throw new DogiException(result.Message);
            }

            return result.Data;
        }

        private static AdminData GetAdminData()
        {
            return new AdminData()
            {
                Id = Guid.NewGuid(),
                Email = "shelter-admin@mock.com"
            };
        }
    }
}