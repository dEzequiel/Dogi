using Domain.Support;

namespace Api.GraphQL.ObjectTypes
{
    public class AnimalZoneType : ObjectType<AnimalZone>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimalZone> descriptor)
        {
            descriptor.Field(f => f.Id)
            .Type<NonNullType<IntType>>();

            descriptor.Field(f => f.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(f => f.Cages)
                .Type<ListType<CageType>>();
        }
    }
}