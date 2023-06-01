
using Application.DTOs.WelcomeManager;
using Application.Features.WelcomeManagerFeature.Command;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using HotChocolate.Resolvers;
using Infraestructure.Helpers;
using MediatR;

namespace Api.GraphQL.Mutations
{
    /// <summary>
    /// WelcomeManagerMutations  public mutations.
    /// </summary>
    [Authorize]
    public class WelcomeManagerMutations
    {
        private readonly IMediator Mediator;
        private readonly ILogger<WelcomeManagerMutations> Logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_mediator"></param>
        /// <param name="_logger"></param>
        public WelcomeManagerMutations(IMediator _mediator, ILogger<WelcomeManagerMutations> _logger)
        {
            Mediator = _mediator;
            Logger = _logger;
        }

        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition you take one way or the other.
        /// </summary>
        /// <param name="Mediator"></param>
        /// <param name="input"></param>
        /// <returns>An object where the information of the reception document and the information of the chip can be consulted together with that of the owner.</returns>
        /// <exception cref="DogiException"></exception>
        public async Task<RegisterInformation> RegisterNewAnimalHost([Service] ISender Mediator,
            [Service]IHttpContextAccessor httpContextAccessor,
            RegisterInformation input)
        {
            try
            {
                Logger.LogInformation("WelcomeManagerMutations --> RegisterNewAnimalHost --> Start");

                var result = await Mediator.Send(new InsertRegisterInformationRequest(input, 
                    GetAdminData(httpContextAccessor)));

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
        private AdminData GetAdminData(IHttpContextAccessor context)
        {
            var user = context.HttpContext.Items["User"] as User;
            
            return new AdminData()
            {
                Id = user.Id,
                Email = user.Username
            };
        }
    }
}
