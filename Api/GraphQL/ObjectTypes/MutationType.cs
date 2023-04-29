﻿using Api.GraphQL.InputObjectTypes;
using Api.GraphQL.Mutations;

namespace Api.GraphQL.Types
{
    /// <inheritdoc />
    public class MutationType : ObjectType
    {
        ///<inheritdoc/>
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
                descriptor.Field("AddReceptionDocumentAsync")
                      .Argument("input", arg => arg.Type<ReceptionDocumentInputType>())
                      .ResolveWith<ReceptionDocumentMutations>(q => q.AddReceptionDocumentAsync(default, default));

                descriptor.Field("MarkReceptionDocumentAsRemovedAsync")
                    .Argument("idToDelete", arg => arg.Type<UuidType>())
                    .ResolveWith<ReceptionDocumentMutations>(q => q.MarkReceptionDocumentAsRemovedAsync(default, default));
        }
    }
}
