using Api.GraphQL.GraphQLTypes;
using Application.Features.ReceptionDocument.Queries;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;

namespace Api.GraphQL.GraphQLQueries
{
    /// <summary>
    /// Each field defined on this type is available at the root of a query.
    /// This class will describe what to expose through GraphQL.
    /// </summary>
    public class Query
    {
        private IMediator _mediator;

        public Query(IMediator mediator)
        {
            _mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        public string Hello() => "Worldd";

        public async Task<ReceptionDocument?> GetReceptionDocument([Service] ISender _mediator, Guid id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetReceptionDocumentByIdRequest(id), ct);
            return result.Data;
        }

    }
}
