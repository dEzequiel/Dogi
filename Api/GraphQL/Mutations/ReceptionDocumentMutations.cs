using Api.GraphQL.InputObjectTypes;
using Application.Features.ReceptionDocument.Commands;
using Ardalis.GuardClauses;
using AutoMapper;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;

namespace Api.GraphQL.Mutations
{
    /// <summary>
    /// Public ReceptionDocument mutations.
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

        /// <summary>
        /// ReceptionDocument entity public mutations.
        /// </summary>

        public async Task<ReceptionDocument> AddReceptionDocumentAsync([Service] ISender _mediator, ReceptionDocument input)
        {

            var result = await _mediator.Send(new InsertReceptionDocumentRequest(input));

            if(!result.Succeeded)
            {

                throw new DogiException(result.Message);
            }


            return result.Data;
        }

        public async Task<bool> MarkReceptionDocumentAsRemovedAsync([Service] ISender _mediator, Guid idToDelete)
        {
            var result = await _mediator.Send(new LogicRemoveReceptionDocumentRequest(idToDelete));

            if(!result.Succeeded)
            {
                throw new DogiException(result.Message);
            }

            return result.Data;
        }
    }
}
