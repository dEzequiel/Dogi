using Application.DTOs.WelcomeManager;
using Application.Features.WelcomeManagerFeature.Command;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using MediatR;

namespace Api.GraphQL.Mutations
{
    /// <summary>
    /// ReceptionDocument entity public mutations.
    /// </summary>
    [ExtendObjectType("Mutation")]
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

        public async Task<ReceptionDocumentWithAnimalOwnerInfo> AddReceptionDocumentWithAnimalChipOwnerInformation([Service] ISender _mediator, ReceptionDocumentWithAnimalOwnerInfo input)
        {
            var result = await _mediator.Send(new InsertReceptionDocumentWithAnimalOwnerInfoRequest(input.ReceptionDocument, input.AnimalChipOwner, GetAdminData()));
            if (!result.Succeeded)
            {
                throw new DogiException(result.Message);
            }
            return result.Data;
        }

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
