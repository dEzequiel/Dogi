using Api.GraphQL.GraphQLQueries;
using Api.GraphQL.GraphQLTypes;
using Api.GraphQL.InputObjectTypes;
using Api.GraphQL.Mutations;
using Api.GraphQL.RootMutations;

namespace Api.GraphQL.Types
{
    /// <inheritdoc />
    public class MutationType : ObjectType<Mutation>
    {
        ///<inheritdoc/>
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(f => f.RegiterNewAnimal)
                    .Argument("input", arg => arg.Type<RegisterAnimalHostInput>())
                    .ResolveWith<WelcomeManagerMutations>(q => q.RegisterNewAnimalHost(default, default));

            descriptor.Field("MarkReceptionDocumentAsRemovedAsync")
                    .Argument("idToDelete", arg => arg.Type<UuidType>())
                    .ResolveWith<ReceptionDocumentMutations>(q => q.MarkReceptionDocumentAsRemovedAsync(default, default));
        }
    }
}
