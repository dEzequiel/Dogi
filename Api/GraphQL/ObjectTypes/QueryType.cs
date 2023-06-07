using Api.GraphQL.EnumType;
using Api.GraphQL.ObjectTypes.Adoption;
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

            #region "MEDICAL RECORDS QUERIES"

            descriptor.Field("GetMedicalRecordsFilterByStatus")
                .Authorize(Permissions.CanReadMedicalRecord.ToString())
                .Type<ListType<MedicalRecordObjectType>>()
                .Argument("status", arg => arg.Type<NonNullType<MedicalRecordStatusEnumType>>())
                .ResolveWith<MedicalRecordQueries>(q => q.GetAllByStatus(default, default, default));

            #endregion

            #region "VACCINES QUERIES"

            descriptor.Field("GetAllVaccinesByAnimalCategory")
                .Authorize(Permissions.CanReadMedicalRecord.ToString())
                .Type<ListType<VaccineObjectType>>()
                .Argument("category", arg => arg.Type<AnimalCategoryEnumType>())
                .ResolveWith<VaccineQueries>(q => q.GetAllByAnimalCategory(default, default, default));

            #endregion

            #region "ADOPTION PENDING QUERIES"

            descriptor.Field("GetAdoptionPendingsFilterByStatus")
                .Authorize()
                .Type<ListType<AdoptionPendingObjectType>>()
                .Argument("status", arg => arg.Type<NonNullType<AdoptionPendingStatusEnumType>>())
                .ResolveWith<AdoptionPendingQueries>(q => q.GetAllAdoptionPendingByStatus(default, default, default));

            #endregion

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