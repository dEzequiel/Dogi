﻿using Application.Features.ReceptionDocument.Queries;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;

namespace Api.GraphQL.GraphQLQueries
{
    /// <summary>
    /// Collection of queries for ReceptionDocument entity.
    /// </summary>
    public class ReceptionDocumentQueries
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ReceptionDocumentQueries()
        {
        }

        public ReceptionDocumentQueries(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IMediator _mediator { get; set;  }

        public async Task<ReceptionDocument?> GetById([Service] ISender _mediator, Guid id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetReceptionDocumentByIdRequest(id), ct);

            if(!result.Succeeded)
            {
                throw new DogiException(result.Message, new KeyNotFoundException(result.Message));
            }

            return result.Data;
        }
    }
}