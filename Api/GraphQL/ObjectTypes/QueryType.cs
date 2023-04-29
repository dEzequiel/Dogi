using Api.GraphQL.GraphQLQueries;

namespace Api.GraphQL.GraphQLTypes
{
    /// <summary>
    /// Public queries assignments.
    /// </summary>
    public class QueryType : ObjectType<Query>
    {

        ///<inheritdoc/>
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(q => q.ReceptionDocumentId)
                .Type<ReceptionDocumentType>()
                .Argument("id", a => a.Type<NonNullType<UuidType>>())
                .ResolveWith<ReceptionDocumentQueries>(q => q.GetById(default, default, default));

            descriptor.Field(q => q.ReceptionDocuments)
                .Type<ListType<ReceptionDocumentType>>()
                .ResolveWith<ReceptionDocumentQueries>(q => q.GetAllPaginatedAsync(default, default));
        }
    }
}
