using Api.GraphQL.InputObjectTypes;
using Api.GraphQL.InputObjectTypes.VeterinaryObjects;
using Api.GraphQL.Mutations;
using Api.GraphQL.RootMutations;

namespace Api.GraphQL.Types
{
    /// <inheritdoc />
    public class MutationType : ObjectType<Mutation>
    {
        ///<inheritdoc/>
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(f => f.RegisterAnimal)
                    .Argument("input", arg => arg.Type<RegisterAnimalHostInput>())
                    .ResolveWith<WelcomeManagerMutations>(q => q.RegisterNewAnimalHost(default, default));



            descriptor.Field("MarkReceptionDocumentAsRemovedAsync")
                    .Argument("idToDelete", arg => arg.Type<UuidType>())
                    .ResolveWith<ReceptionDocumentMutations>(q => q.MarkReceptionDocumentAsRemovedAsync(default, default));

            #region "VETERINARY MANAGER MUTATIONS"

            descriptor.Field(f => f.CreateMedicalRecord)
                .Argument("individualProceedingId", arg => arg.Type<NonNullType<UuidType>>())
                .Argument("medicalRecord", arg => arg.Type<NonNullType<MedicalRecordInput>>())
                .Argument("vaccinesIds", arg => arg.Type<ListType<UuidType>>())
                .ResolveWith<VeterinaryManagerMutations>(q => q.CreateMedicalRecord(default, default, default, default));

            descriptor.Field(f => f.CheckMedicalRecord)
                .Argument("medicalRecordId", arg => arg.Type<NonNullType<UuidType>>())
                .Argument("observations", arg => arg.Type<StringType>())
                .ResolveWith<VeterinaryManagerMutations>(q => q.CheckMedicalRecord(default, default, default));

            descriptor.Field(f => f.CloseMedicalRecord)
                .Argument("medicalRecordId", arg => arg.Type<NonNullType<UuidType>>())
                .Argument("conclusions", arg => arg.Type<NonNullType<StringType>>())
                .ResolveWith<VeterinaryManagerMutations>(q => q.CloseMedicalRecord(default, default, default));

            //descriptor.Field(f => f.AssignVaccine)
            //    .Argument("input", arg => arg.Type<VaccinationCardWithVaccineCredentialsInput>())
            //    .ResolveWith<VeterinaryManagerMutations>(v => v.AssignVaccine(default, default));

            descriptor.Field(f => f.Vaccine)
                .Argument("input", arg => arg.Type<VaccinationCardWithVaccineCredentialsInput>())
                .ResolveWith<VeterinaryManagerMutations>(v => v.Vaccine(default, default));

            #endregion

            #region "VACCINE MUTATIONS"

            descriptor.Field(f => f.AddVaccine)
                .Argument("input", arg => arg.Type<ListType<VaccineInput>>())
                .ResolveWith<VaccineMutations>(q => q.AddVaccine(default, default));

            #endregion
        }
    }
}
