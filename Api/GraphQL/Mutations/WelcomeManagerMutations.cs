using System.Security.Claims;
using Application.DTOs.WelcomeManager;
using Application.Features.WelcomeManagerFeature.Command;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using MediatR;

namespace Api.GraphQL.Mutations
{
    /// <summary>
    /// WelcomeManagerMutations  public mutations.
    /// </summary>
    public class WelcomeManagerMutations
    {
        private readonly ILogger<WelcomeManagerMutations> Logger;
        private readonly ClaimsPrincipal _claimsPrincipal;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="claimsPrincipal"></param>
        public WelcomeManagerMutations(ILogger<WelcomeManagerMutations> logger, ClaimsPrincipal claimsPrincipal)
        {
            Logger = logger;
            _claimsPrincipal = claimsPrincipal;
        }

        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition
        /// you take one way or the other.
        /// </summary>
        /// <param name="Mediator"></param>
        /// <param name="input"></param>
        /// <returns>An object where the information of the reception document and the information of the chip
        /// can be consulted together with that of the owner.</returns>
        /// <exception cref="DogiException"></exception>
        public async Task<RegisterInformation> RegisterNewAnimalHost([Service] ISender Mediator,
            RegisterInformation input)
        {
            try
            {
                Logger.LogInformation("WelcomeManagerMutations --> RegisterNewAnimalHost --> Start");

                var result = await Mediator.Send(new InsertRegisterInformationRequest(input,
                    GetAdminData()));

                Logger.LogInformation("WelcomeManagerMutations --> RegisterNewAnimalHost --> End");

                return result.Data!;
            }
            catch (DogiException ex)
            {
                Logger.LogInformation("WelcomeManagerMutations --> RegisterNewAnimalHost --> Error");

                throw new DogiException(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogInformation("WelcomeManagerMutations --> RegisterNewAnimalHost --> Error");
                throw new DogiException(ex.Message);
            }
        }

        /// <summary>
        /// Get current user information.
        /// </summary>
        /// <returns>Object representing user information.</returns>
        private AdminData GetAdminData()
        {
            return new AdminData
            {
                Id = Guid.Parse(_claimsPrincipal.FindFirstValue("Id")),
                Email = _claimsPrincipal.FindFirstValue("Email")
            };
        }
    }
}