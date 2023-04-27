using Application.DTOs.ReceptionDocument;
using Application.Features.ReceptionDocument.Queries;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using Infraestructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<ApiResponse<ReceptionDocumentForGet>?> GetReceptionDocument(Guid id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetReceptionDocumentByIdRequest(id), ct);

            if (!result.Succeeded)
            {
                return new("not found");
            }

            return result;
        }
    }

    /// <summary>
    /// The query type in GraphQL represents a read-only view of all of our entities and ways to retrieve them.
    /// </summary>
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(q => q.GetReceptionDocument(default, default))
                .Type<ReceptionDocumentType>()
                .Argument("id", a => a.Type<NonNullType<UuidType>>());
        }
    }


}
