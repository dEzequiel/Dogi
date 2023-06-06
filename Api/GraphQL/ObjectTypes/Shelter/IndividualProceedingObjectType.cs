using Api.GraphQL.ObjectTypes.Veterinary;
using Domain.Entities.Shelter;
using Domain.Enums.Authorization;

namespace Api.GraphQL.ObjectTypes.Shelter
{
    ///<summary>
    /// IndividualProceeding HotChocolate Type implementation.
    ///</summary>
    public class IndividualProceedingObjectType : ObjectType<IndividualProceeding>
    {
        protected override void Configure(IObjectTypeDescriptor<IndividualProceeding> descriptor)
        {
            descriptor.Authorize(Permissions.CanReadIndividualProceeding.ToString());

            descriptor.Field(f => f.MedicalRecords).Type<ListType<MedicalRecordType>>();
            descriptor.Field(f => f.VaccinationCard).Type<VaccinationCardType>();

            descriptor.Field(f => f.VaccinationCard)
                .Authorize(Permissions.CanReadVaccinationCard.ToString());
            descriptor.Field(f => f.MedicalRecords)
                .Authorize(Permissions.CanReadMedicalRecord.ToString());

            descriptor.Ignore(f => f.ReceptionDocumentId);
            descriptor.Ignore(f => f.VaccinationCardId);
            descriptor.Ignore(f => f.CageId);
            descriptor.Ignore(f => f.SexId);
            descriptor.Ignore(f => f.CategoryId);
            descriptor.Ignore(f => f.IndividualProceedingStatusId);
            descriptor.Ignore(f => f.IsDeleted);
        }
    }
}