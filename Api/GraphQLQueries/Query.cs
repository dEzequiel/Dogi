using Api.GraphQLTypes;
using Application.Service.Interfaces;
using Domain.Entities;
using Infraestructure.Context;

namespace Api.GraphQLQueries
{
    /// <summary>
    /// Each field defined on this type is available at the root of a query.
    /// This class will describe what to expose through GraphQL.
    /// </summary>
    public class Query
    {
        public string Hello() => "World";
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ReceptionDocument>> GetReceptionDocuments(
            [Service] IReceptionDocumentRepository repository)
        {
           return await repository.GetAllAsync();

        }

        public async Task<ReceptionDocument?> GetReceptionDocumentById([Service] IReceptionDocumentRepository repository,
            Guid id)
        {
            return await repository.GetAsync(id);
        }
        
    }

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(f => f.GetReceptionDocuments(default!))
                .Type<ListType<ReceptionDocumentType>>();

            descriptor
                .Field(f => f.Hello())
                .Type<StringType>();
        }
    }
}
