using Application.DTOs.VeterinaryManager;
using Application.Features.VeterinaryManager.Command;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
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

        public async Task<InvidiualProceedingWithMedicalRecord> CheckMedicalRecord([Service] ISender Mediator,
            Guid medicalRecordId)
        {
            try
            {
                Logger.LogInformation("VeterinaryManagerMutations --> CheckMedicalRecord --> Start");

                var result = await Mediator.Send(new CheckMedicalRecordRequest(medicalRecordId, GetAdminData()));

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
