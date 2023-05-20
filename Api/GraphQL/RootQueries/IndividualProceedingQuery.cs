using Domain.Entities;

namespace Api.GraphQL.GraphQLQueries
{
    /// <summary>
    /// Public queries.
    /// </summary>
    public partial class Query
    {
        /// <summary>
        /// Public IndividualProceeding queries.
        /// </summary>
        public IndividualProceeding? IndividualProceedingId { get; }
    }
}
