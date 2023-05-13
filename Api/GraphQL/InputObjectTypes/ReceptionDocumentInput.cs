﻿using Domain.Entities;

namespace Api.GraphQL.InputObjectTypes
{
    /// <summary>
    /// ReceptionDocument input type for graphql mutations.
    /// </summary>
    public class ReceptionDocumentInput : InputObjectType<ReceptionDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReceptionDocument> descriptor)
        {
            descriptor
            .Field(f => f.Id)
            .Type<NonNullType<UuidType>>()
            .Ignore(true);

            descriptor.Field(f => f.IsDeleted)
                .Type<NonNullType<BooleanType>>()
                .DefaultValue(false)
                .Ignore(true);

            descriptor.Field(f => f.HasChip)
                .Type<BooleanType>();

            descriptor.Field(f => f.Observations)
                .Type<StringType>();

            descriptor.Field(f => f.PickupLocation)
                .Type<NonNullType<StringType>>();

            //descriptor.Field(f => f.PickupDate)
            //    .Type<NonNullType<DateType>>()
            //    .DefaultValue(DateTimeOffset.Now);

            descriptor.Ignore(f => f.IndividualProceeding);
            descriptor.Ignore(f => f.Created);
            descriptor.Ignore(f => f.CreatedBy);
            descriptor.Ignore(f => f.LastModified);
            descriptor.Ignore(f => f.LastModifiedBy);

        }
    }

}
