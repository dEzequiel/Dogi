using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Api.GraphQL.ObjectTypes
{
    ///<summary>
    /// IndividualProceeding HotChocolate Type implementation.
    ///</summary>
    public class IndividualProceedingType : ObjectType<IndividualProceeding>
    {
        protected override void Configure(IObjectTypeDescriptor<IndividualProceeding> descriptor)
        {
            descriptor.Field(f => f.Id)
            .Type<NonNullType<UuidType>>();

            descriptor.Field(f => f.IsDeleted)
                .Type<NonNullType<BooleanType>>();

            descriptor.Field(f => f.StatusId)
                .Type<NonNullType<IntType>>();
            
            descriptor.Field(f => f.CategoryId)
                .Type<NonNullType<UuidType>>();

            descriptor.Field(f => f.SexId)
                .Type<NonNullType<IntType>>();
            
            descriptor.Ignore(f => f.ReceptionDocument);
            descriptor.Ignore(f => f.ProceedingStatus);
            descriptor.Ignore(f => f.AnimalCategory);
            descriptor.Ignore(f => f.Sex);
        }
    }
}