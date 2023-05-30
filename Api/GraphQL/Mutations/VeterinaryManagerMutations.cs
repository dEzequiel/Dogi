using Application.DTOs.VeterinaryManager;
using Application.Features.VaccinationCardVaccine.Commands;
using Application.Features.VeterinaryManager.Command;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using MediatR;

namespace Api.GraphQL.Mutations
{
    public class VeterinaryManagerMutations
    {
        private readonly IMediator Mediator;
        private readonly ILogger<VeterinaryManagerMutations> Logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public VeterinaryManagerMutations(IMediator mediator, ILogger<VeterinaryManagerMutations> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }



        public async Task<IndividualProceedingWithMedicalRecord> CheckMedicalRecord([Service] ISender Mediator,
            Guid medicalRecordId, string? observations)
        {
            try
            {
                Logger.LogInformation("VeterinaryManagerMutations --> CheckMedicalRecord --> Start");

                var result = await Mediator.Send(new CheckMedicalRecordRequest(medicalRecordId, observations, GetAdminData()));

                Logger.LogInformation("VeterinaryManagerMutations --> CheckMedicalRecord --> End");

                return result.Data!;
            }
            catch (DogiException ex)
            {
                Logger.LogInformation("WelcomeManagerMutations --> RegisterNewAnimalHost --> Error");

                throw new DogiException(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogInformation("VeterinaryManagerMutations --> CheckMedicalRecord --> Error");
                throw new DogiException(ex.Message);
            }
        }

        public async Task<IndividualProceedingWithMedicalRecord> CloseMedicalRecord([Service] ISender Mediator,
            Guid medicalRecordId, string conclusions)
        {
            try
            {
                Logger.LogInformation("VeterinaryManagerMutations --> CloseMedicalRecord --> Start");

                var result = await Mediator.Send(new CloseMedicalRecordRequest(medicalRecordId, conclusions, GetAdminData()));

                Logger.LogInformation("VeterinaryManagerMutations --> CloseMedicalRecord --> End");

                return result.Data!;
            }
            catch (DogiException ex)
            {
                Logger.LogInformation("VeterinaryManagerMutations --> CloseMedicalRecord --> Error");

                throw new DogiException(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogInformation("VeterinaryManagerMutations --> CloseMedicalRecord --> Error");

                throw new DogiException(ex.Message);
            }
        }

        public async Task<IndividualProceedingWithVaccinationCard> AssignVaccine([Service] ISender Mediator,
            VaccinationCardWithVaccineCredentials input)
        {
            try
            {
                Logger.LogInformation("VeterinaryManagerMutations --> AssignVaccine --> Start");

                var result = await Mediator.Send(new AssignVaccineRequest(input.VaccinationCardId,
                                                                          input.VaccineId,
                                                                          GetAdminData()));

                Logger.LogInformation("VeterinaryManagerMutations --> AssignVaccine --> End");

                return result.Data!;
            }
            catch (DogiException ex)
            {
                Logger.LogInformation("VeterinaryManagerMutations --> AssignVaccine --> Error");

                throw new DogiException(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogInformation("VeterinaryManagerMutations --> AssignVaccine --> Error");

                throw new DogiException(ex.Message);
            }
        }

        public async Task<VaccinationCardVaccine> Vaccine([Service] ISender Mediator, VaccinationCardWithVaccineCredentials input)
        {
            try
            {
                Logger.LogInformation("VeterinaryManagerMutations --> Vaccine --> Start");

                var result = await Mediator.Send(new VaccineExistingVaccinationCardVaccineVaccineRequest(input.VaccinationCardId,
                                                                                                         input.VaccineId,
                                                                                                         GetAdminData()));

                Logger.LogInformation("VeterinaryManagerMutations --> Vaccine --> End");

                return result.Data!;
            }
            catch (DogiException ex)
            {
                Logger.LogInformation("VeterinaryManagerMutations --> Vaccine --> Error");

                throw new DogiException(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogInformation("VeterinaryManagerMutations --> Vaccine --> Error");

                throw new DogiException(ex.Message);
            }
        }

        /// <summary>
        /// Get current user information.
        /// </summary>
        /// <returns>Object representing user information.</returns>
        private static AdminData GetAdminData()
        {
            return new AdminData()
            {
                Id = Guid.NewGuid(),
                Email = "shelter-admin@mock.com"
            };
        }
    }
}
