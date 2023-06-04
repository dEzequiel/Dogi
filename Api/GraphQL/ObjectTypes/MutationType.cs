using Api.GraphQL.InputObjectTypes.Authorization;
using Api.GraphQL.InputObjectTypes.Shelter;
using Api.GraphQL.InputObjectTypes.Veterinary;
using Api.GraphQL.InputObjectTypes.VeterinaryObjects;
using Api.GraphQL.Mutations;
using Domain.Enums.Authorization;
using HotChocolate.Authorization;

namespace Api.GraphQL.ObjectTypes
{
    /// <inheritdoc />
    public class MutationType : ObjectType<Mutation>
    {
        ///<inheritdoc/>
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field("RegisterAnimal")
                .Argument("input", arg => arg.Type<RegisterAnimalHostInput>())
                .ResolveWith<WelcomeManagerMutations>(q => q.RegisterNewAnimalHost(default,
                    default, default))
                .Authorize(Permissions.CanRegister.ToString(), ApplyPolicy.AfterResolver);

            descriptor.Field("MarkReceptionDocumentAsRemovedAsync")
                .Argument("idToDelete", arg => arg.Type<UuidType>())
                .ResolveWith<ReceptionDocumentMutations>(q => q.MarkReceptionDocumentAsRemovedAsync(default, default));

            #region "VETERINARY MANAGER MUTATIONS"

            descriptor.Field("CreateMedicalRecord")
                .Argument("individualProceedingId", arg => arg.Type<NonNullType<UuidType>>())
                .Argument("medicalRecord", arg => arg.Type<NonNullType<MedicalRecordInput>>())
                .Argument("vaccinesIds", arg => arg.Type<ListType<UuidType>>())
                .ResolveWith<VeterinaryManagerMutations>(q =>
                    q.CreateMedicalRecord(default, default, default, default));

            descriptor.Field("CheckMedicalRecord")
                .Argument("medicalRecordId", arg => arg.Type<NonNullType<UuidType>>())
                .Argument("observations", arg => arg.Type<StringType>())
                .ResolveWith<VeterinaryManagerMutations>(q => q.CheckMedicalRecord(default, default, default));

            descriptor.Field("CloseMedicalRecord")
                .Argument("medicalRecordId", arg => arg.Type<NonNullType<UuidType>>())
                .Argument("conclusions", arg => arg.Type<NonNullType<StringType>>())
                .ResolveWith<VeterinaryManagerMutations>(q => q.CloseMedicalRecord(default, default, default));

            //descriptor.Field(f => f.AssignVaccine)
            //    .Argument("input", arg => arg.Type<VaccinationCardWithVaccineCredentialsInput>())
            //    .ResolveWith<VeterinaryManagerMutations>(v => v.AssignVaccine(default, default));

            descriptor.Field("Vaccine")
                .Argument("input", arg => arg.Type<VaccinationCardWithVaccineCredentialsInput>())
                .ResolveWith<VeterinaryManagerMutations>(v => v.Vaccine(default, default));

            #endregion

            #region "VACCINE MUTATIONS"

            descriptor.Field("AddVaccine")
                .Argument("input", arg => arg.Type<ListType<VaccineInput>>())
                .ResolveWith<VaccineMutations>(q => q.AddVaccine(default, default));

            #endregion

            #region "USER MUTATIONS"

            descriptor.Field("RegisterUser")
                .Argument("credentials", arg => arg.Type<UserRegisterInputType>())
                .ResolveWith<UserManagerMutations>(v => v.Register(default, default));

            descriptor.Field("LoginUser")
                .Argument("credentials", arg => arg.Type<UserLoginInputType>())
                .ResolveWith<UserManagerMutations>(v => v.Authenticate(default, default));

            descriptor.Field("AssigneRole")
                .Authorize("CanAssigneRole")
                .Argument("userWithRoles", arg => arg.Type<NonNullType<UserWithRolesInputType>>())
                .ResolveWith<UserManagerMutations>(v => v.AssigneRole(default, default));

            #endregion
        }
    }
}