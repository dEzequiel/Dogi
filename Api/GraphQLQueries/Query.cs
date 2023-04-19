using Domain.Entities;

namespace Api.GraphQLQueries
{
    public class Query
    {
        /// <summary>
        /// Resolver. 
        /// </summary>
        /// <returns></returns>
        public ReceptionDocument GetBook() => new ReceptionDocument { Id = Guid.NewGuid(), Observations = "Hello HotChocolate", HasChip = null, IndividualProceeding = null, PickupDate = null, PickupLocation = null};
    }
}
