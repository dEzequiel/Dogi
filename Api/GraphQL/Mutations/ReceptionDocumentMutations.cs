using Application.Features.ReceptionDocument.Commands;
using Ardalis.GuardClauses;
using AutoMapper;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;

namespace Api.GraphQL.Mutations
{
    /// <summary>
    /// ReceptionDocument entity public mutations.
    /// </summary>
    [ExtendObjectType("Mutation")]
    public class ReceptionDocumentMutations
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        public ReceptionDocumentMutations(IMediator mediator, ILogger<ReceptionDocumentMutations> logger, IMapper mapper)
        {
            _mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        public ReceptionDocumentMutations()
        {
        }


        public async Task<ReceptionDocument> AddReceptionDocumentAsync([Service] ISender _mediator, ReceptionDocument input)
        {

            var result = await _mediator.Send(new InsertReceptionDocumentRequest(input, GetAdminData()));

            if(!result.Succeeded)
            {

                throw new DogiException(result.Message);
            }


            return result.Data;                                                                                                                        
        }

        public async Task<bool> MarkReceptionDocumentAsRemovedAsync([Service] ISender _mediator, Guid idToDelete)
        {
            var result = await _mediator.Send(new LogicRemoveReceptionDocumentRequest(idToDelete, GetAdminData()));

            if(!result.Succeeded)
            {
                throw new DogiException(result.Message);
            }

            return result.Data;
        }

        private AdminData GetAdminData()
        {
            return new AdminData()
            {
                Id = Guid.NewGuid(),
                Email = "shelter-admin@mock.com"
            };
        }
    }
}
