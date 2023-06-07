using Api.GraphQL.EnumType;
using Api.GraphQL.ObjectTypes.Shelter;
using Api.GraphQL.ObjectTypes.Veterinary;
using Api.GraphQL.Queries;
using Domain.Enums.Authorization;
using HotChocolate.Types.Pagination;

namespace Api.GraphQL.ObjectTypes
{
    /// <summary>
    /// Public queries assignments.
    /// </summary>
    public class QueryType : ObjectType<Query>
    {
        ///<inheritdoc/>
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            #region "INDIVIDUAL PROCEEDING QUERIES"

            descriptor.Field("GetIndividualProceedingFilterByStatus")
                .Authorize(Permissions.CanReadIndividualProceeding.ToString())
                .Type<ListType<IndividualProceedingObjectType>>()
                .Argument("status", arg => arg.Type<NonNullType<IndividualProceedingStatusEnumType>>())
                .ResolveWith<IndividualProceedingQueries>(q => q.GetAllByStatus(default, default, default));

            #endregion

            descriptor.Field("GetMedicalRecordsFilterByStatus")
                .Authorize(Permissions.CanReadMedicalRecord.ToString())
                .Type<ListType<MedicalRecordObjectType>>()
                .Argument("status", arg => arg.Type<NonNullType<MedicalRecordStatusEnumType>>())
                .ResolveWith<MedicalRecordQueries>(q => q.GetAllByStatus(default, default, default));


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

            descriptor.Field("GetById")
                .Type<ReceptionDocumentObjectType>()
                .Argument("id", a => a.Type<NonNullType<UuidType>>())
                .ResolveWith<ReceptionDocumentQueries>(q => q.GetById(default, default, default));

            descriptor.Field("GetAll")
                .Type<ReceptionDocumentObjectType>()
                .UsePaging<ReceptionDocumentObjectType>(
                    options: new PagingOptions
                    {
                        DefaultPageSize = 10,
                        MaxPageSize = 20,
                        IncludeTotalCount = true
                    })
                .ResolveWith<ReceptionDocumentQueries>(q => q.GetAllPaginatedAsync(default, default));

            descriptor.Field("GetByChip")
                .Type<ReceptionDocumentObjectType>()
                .Argument("hasChip", a => a.Type<BooleanType>())
                .UsePaging<ReceptionDocumentObjectType>(
                    options: new PagingOptions
                    {
                        DefaultPageSize = 10,
                        MaxPageSize = 20,
                        IncludeTotalCount = true
                    })
                .ResolveWith<ReceptionDocumentQueries>(q =>
                    q.GetAllFilterByChipPossessionPaginatedAsync(default, default, default));
        }
    }
}