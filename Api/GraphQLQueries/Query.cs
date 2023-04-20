using Domain.Entities;
using Infraestructure.Context;

namespace Api.GraphQLQueries
{
    public class Query
    {
        /// <summary>
        /// Resolver. 
        /// </summary>
        /// <returns></returns>
        public IQueryable<ReceptionDocument> GetReceptionDocuments([Service] ApplicationDbContext context) =>
            context.ReceptionDocument;
    }
}
