using Domain.Entities;

namespace Api.GraphQL.GraphQLQueries
{
    /// <summary>
    /// Public queries.
    /// </summary>
    public partial class Query
    {
        /// <summary>
        /// Animal entity public queries.
        /// </summary>
        public Animal? Animal { get; }
    }
}
