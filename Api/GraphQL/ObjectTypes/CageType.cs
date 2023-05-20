using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    public class CageType : ObjectType<Cage>
    {
        protected override void Configure(IObjectTypeDescriptor<Cage> descriptor)
        {
            descriptor.Field(f => f.Id)
            .Type<NonNullType<UuidType>>();

            descriptor.Field(f => f.Number)
                .Type<NonNullType<IntType>>();

            descriptor.Field(f => f.AnimalZoneId)
                .Type<NonNullType<StringType>>();

            descriptor.Field(f => f.AnimalZone)
                .Type<AnimalZoneType>();
        }
    }
}
