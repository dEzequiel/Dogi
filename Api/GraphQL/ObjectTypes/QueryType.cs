using System.Diagnostics;
using System.Security.Claims;
using Api.GraphQL.GraphQLQueries;
using Api.GraphQL.ObjectTypes;
using Application.Service.Interfaces;
using HotChocolate.Types.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;

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
            
            
            /*descriptor.Field("GetAllMedicalRecordByStatus")
                .Type<ListType<MedicalRecordType>>()
                .Argument("status", a => a.Type<NonNullType<IntType>>())
                .Authorize()
                .ResolveWith<VeterinaryManagerQueries>(q =>
                    q.GetAllByStatus(default, default, default));
            
            descriptor.Field("GetAllMedicalRecord")
                .Type<ListType<MedicalRecordType>>()
                .ResolveWith<VeterinaryManagerQueries>(q => 
                    q.GetAllAsync(default, default));*/
            
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

            descriptor.Field(q => q.ReceptionDocumentsFilterByChip)
                .Type<ReceptionDocumentType>()
                .Argument("hasChip", a => a.Type<BooleanType>())
                .UsePaging<ReceptionDocumentType>(
                options: new PagingOptions
                {
                    DefaultPageSize = 10,
                    MaxPageSize = 20,
                    IncludeTotalCount = true
                })
                .ResolveWith<ReceptionDocumentQueries>(q => q.GetAllFilterByChipPossessionPaginatedAsync(default, default, default));
        }
    }
}
