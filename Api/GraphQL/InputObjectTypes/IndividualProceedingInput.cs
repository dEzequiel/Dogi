using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    /// <summary>
    /// IndividualProceeding input object type.
    /// </summary>
    public class IndividualProceedingInput : InputObjectType<IndividualProceeding>
    {
        protected override void Configure(IInputObjectTypeDescriptor<IndividualProceeding> descriptor)
        {
            descriptor.Field(f => f.StatusId)
                .Type<NonNullType<IntType>>();
            
            descriptor.Field(f => f.CategoryId)
                .Type<NonNullType<UuidType>>();
            
            descriptor.Field(f => f.SexId)
                .Type<NonNullType<IntType>>();
            
            descriptor.Ignore(f => f.Id);
            descriptor.Ignore(f => f.IsDeleted);
            descriptor.Ignore(f => f.ReceptionDocument);
            descriptor.Ignore(f => f.ProceedingStatus);
            descriptor.Ignore(f => f.AnimalCategory);
            descriptor.Ignore(f => f.Sex);
            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.CreatedBy);
            descriptor.Ignore(f => f.LastModified);
            descriptor.Ignore(f => f.LastModifiedBy);
        }
    }
}