using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    public class VaccineType : ObjectType<Vaccine>
    {
        protected override void Configure(IObjectTypeDescriptor<Vaccine> descriptor)
        {

        }
    }
}
