using Application.DTOs.WelcomeManager;
using Application.Features.WelcomeManagerFeature.Command;
using Ardalis.GuardClauses;
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
        public IMediator _mediator { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        public WelcomeManagerMutations(IMediator mediator)
        {
            _mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        public WelcomeManagerMutations() { }

        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition you take one way or the other.
        /// </summary>
        /// <param name="_mediator"></param>
        /// <param name="input"></param>
        /// <returns>An object where the information of the reception document and the information of the chip can be consulted together with that of the owner.</returns>
        /// <exception cref="DogiException"></exception>
        public async Task<ReceptionDocumentWithAnimalOwnerInfo> AddReceptionDocumentWithAnimalChipOwnerInformation([Service] ISender _mediator, 
            ReceptionDocumentWithAnimalOwnerInfo input)
        {
            var result = await _mediator.Send(new InsertReceptionDocumentWithAnimalOwnerInfoRequest(input, 
                GetAdminData()));

            if (!result.Succeeded)
            {
                throw new DogiException(result.Message);
            }
            return result.Data;
        }

        /// <summary>
        /// Get current user information.
        /// </summary>
        /// <returns>Object representing user information.</returns>
        private AdminData GetAdminData()
        {
            return new AdminData()
            {
                Id = Guid.NewGuid(),
                Email = "shelter-admin@mock.com"
            };
        }
    }
}
