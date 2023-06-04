using Api.GraphQL.ObjectTypes.Shelter;
using Domain.Entities;

namespace Api.GraphQL.ObjectTypes.Veterinary
{
    public class VaccinationCardType : ObjectType<VaccinationCard>
    {
        protected override void Configure(IObjectTypeDescriptor<VaccinationCard> descriptor)
        {
            descriptor.Field(f => f.Id).Type<NonNullType<UuidType>>();
            descriptor.Field(f => f.Observations).Type<StringType>();
            //descriptor.Field(f => f.VaccinationCardVaccines).Type<ListType<VaccinationCardVaccine>>();
            descriptor.Field(f => f.IndividualProceeding).Type<IndividualProceedingType>();
        }
    }
}