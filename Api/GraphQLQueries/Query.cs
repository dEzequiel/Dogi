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
        public string Hello() => "Worldd";

        public ReceptionDocument? GetReceptionDocument(Guid id)
        {
            var objec = new ReceptionDocument(Guid.Parse("83cff3cd-b820-4b7b-9333-f7ec1b7a6faf"), false, 
                "test", "test",
                DateTime.Now);

            if (objec.Id == id)
                return objec;

            return null;
        }
    }

    /// <summary>
    /// The query type in GraphQL represents a read-only view of all of our entities and ways to retrieve them.
    /// </summary>
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(q => q.GetReceptionDocument(default))
                .Type<ReceptionDocumentType>()
                .Argument("id", a => a.Type<NonNullType<UuidType>>());
        }
    }
    
    
}
