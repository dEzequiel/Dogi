using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    public class VaccineInput : InputObjectType<Vaccine>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Vaccine> descriptor)
        {
            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.AnimalCategory);
            //descriptor.Ignore(f => f.VaccinationCards);
        }
    }
}
