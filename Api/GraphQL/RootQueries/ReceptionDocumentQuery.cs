using Domain.Entities;

namespace Api.GraphQL.GraphQLQueries
{
    /// <summary>
    /// Public queries.
    /// </summary>
    public partial class Query
    {
        /// <summary>
        /// Reception Document entity public queries.
        /// </summary>
        public ReceptionDocument? ReceptionDocumentId { get; }
        //public IEnumerable<ReceptionDocument>? ReceptionDocuments { get; }
    }
}
