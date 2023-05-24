using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    public class VaccinationCardType : InputObjectType<VaccinationCard>
    {
        protected override void Configure(IInputObjectTypeDescriptor<VaccinationCard> descriptor)
        {
        }
    }
}
