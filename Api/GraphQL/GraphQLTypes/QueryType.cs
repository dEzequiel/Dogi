using Api.GraphQL.GraphQLQueries;

namespace Api.GraphQL.GraphQLTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(q => q.GetReceptionDocument(default,  default, default))
                .Type<ReceptionDocumentType>()
                .Argument("id", a => a.Type<NonNullType<UuidType>>());
        }
    }
}
