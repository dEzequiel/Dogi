using Api.GraphQL.GraphQLQueries;
using HotChocolate.Types.Pagination;

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
                .Type<ReceptionDocumentType>()
                .UsePaging<ReceptionDocumentType>(
                options: new PagingOptions
                {
                    DefaultPageSize = 10,
                    MaxPageSize = 20,
                    IncludeTotalCount = true
                })
                .ResolveWith<ReceptionDocumentQueries>(q => q.GetAllPaginatedAsync(default, default));
        }
    }
}
