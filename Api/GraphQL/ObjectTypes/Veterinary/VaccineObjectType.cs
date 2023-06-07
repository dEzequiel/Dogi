using Domain.Entities;

namespace Api.GraphQL.ObjectTypes.Veterinary
{
    public class VaccineObjectType : ObjectType<Vaccine>
    {
        protected override void Configure(IObjectTypeDescriptor<Vaccine> descriptor)
        {
            descriptor.Field(f => f.Id).Type<UuidType>();
            descriptor.Field(f => f.Name).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.AnimalCategoryId).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.Description).Type<StringType>();
            descriptor.Field(f => f.AnimalCategory).Type<ListType<VaccinationCardType>>();

            descriptor.Ignore(f => f.AnimalCategoryId);
        }
    }
}