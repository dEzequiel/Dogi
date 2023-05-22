using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Api.GraphQL.GraphQLTypes;
using HotChocolate;

namespace Test.Api
{
    public class ReceptionDocumentQueriesTest
    {
        [Fact]
        public async Task SchemaChangeTest()
        {
            var schema = await TestServices.Executor.GetSchemaAsync(default);
            schema.ToString().MatchSnapshot();
        }

        [Fact]
        public async Task FetchReceptionDocumentById()
        {
            var result = await TestServices.ExecuteRequestAsync(
                b => b.SetQuery("{ receptionDocuments { totalCount } }"));

            result.MatchSnapshot();
        }
    }

    public static class TestServices
    {
        static TestServices()
        {
            Services = new ServiceCollection()
                .AddGraphQLServer()
                .AddQueryType<QueryType>()
                .Services
                .AddSingleton(
                    sp => new RequestExecutorProxy(
                        sp.GetRequiredService<IRequestExecutorResolver>(),
                        Schema.DefaultName))
                .BuildServiceProvider();

            Executor = Services.GetRequiredService<RequestExecutorProxy>();
        }

        public static IServiceProvider Services { get; }

        public static RequestExecutorProxy Executor { get; }

        public static async Task<string> ExecuteRequestAsync(
            Action<IQueryRequestBuilder> configureRequest,
            CancellationToken cancellationToken = default)
        {
            await using var scope = Services.CreateAsyncScope();

            var requestBuilder = new QueryRequestBuilder();
            requestBuilder.SetServices(scope.ServiceProvider);
            configureRequest(requestBuilder);
            var request = requestBuilder.Create();

            await using var result = await Executor.ExecuteAsync(request, cancellationToken);

            result.ExpectQueryResult();

            return result.ToJson();
        }

        public static async IAsyncEnumerable<string> ExecuteRequestAsStreamAsync(
            Action<IQueryRequestBuilder> configureRequest,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await using var scope = Services.CreateAsyncScope();

            var requestBuilder = new QueryRequestBuilder();
            requestBuilder.SetServices(scope.ServiceProvider);
            configureRequest(requestBuilder);
            var request = requestBuilder.Create();

            await using var result = await Executor.ExecuteAsync(request, cancellationToken);

            await foreach (var element in result.ExpectResponseStream().ReadResultsAsync().WithCancellation(cancellationToken))
            {
                await using (element)
                {
                    yield return element.ToJson();
                }
            }
        }
    }
}
