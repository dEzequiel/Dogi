using Application.Features.ReceptionDocument.Queries;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Domain.Enums;
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

        public async Task<IEnumerable<ReceptionDocument>> GetAllPaginatedAsync([Service] ISender _mediator, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetAllReceptionDocumentsRequest(), ct);

            return result.Data;
        }

        public async Task<IEnumerable<ReceptionDocument>> GetAllFilterByChipPossessionPaginatedAsync([Service] ISender _mediator, bool hasChip,
            CancellationToken ct  = default)
        {
            var result = await _mediator.Send(new GetAllReceptionDocumentsFilterByChipRequest(hasChip), ct);

            return result.Data;
        }
    }
}