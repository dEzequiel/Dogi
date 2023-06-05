using Api.GraphQL.EnumType;
using Domain.Entities.Adoption;

namespace Api.GraphQL.InputObjectTypes.Adoption;

public class AdoptionApplicationInputType : InputObjectType<AdoptionApplication>
{
    protected override void Configure(IInputObjectTypeDescriptor<AdoptionApplication> descriptor)
    {
        descriptor.Field(f => f.HousingTypeId).Type<NonNullType<HousingTypeEnumType>>();

        descriptor.Field(f => f.HouseDescription).Type<NonNullType<HouseDescriptionInputType>>();
        descriptor.Field(f => f.OtherAnimals).Type<OtherAnimalInputType>();
        descriptor.Field(f => f.PersonalReferences).Type<PersonalReferenceInputType>();

        descriptor.Ignore(f => f.Id);
        descriptor.Ignore(f => f.AdoptionPending);
        descriptor.Ignore(f => f.User);
        descriptor.Ignore(f => f.HousingType);
        descriptor.Ignore(f => f.AdoptionApplicationStatus);
        descriptor.Ignore(f => f.AdoptionPendingId);
        descriptor.Ignore(f => f.UserId);

        descriptor.Ignore(f => f.Created);
        descriptor.Ignore(f => f.CreatedBy);
        descriptor.Ignore(f => f.LastModified);
        descriptor.Ignore(f => f.LastModifiedBy);
    }
}