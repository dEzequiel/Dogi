using System.Security.Claims;
using Domain.Entities;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;

namespace Api.GraphQL.Helpers;

/// <summary>
/// Modify incoming HTTP request before it is passed to the execution engine.
/// </summary>
public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
{
    private const string USER_KEY = "User";
    private const string ID_KEY = "Id";

    public override ValueTask OnCreateAsync(HttpContext context, IRequestExecutor requestExecutor,
        IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
    {
        var user = (User)context.Items[USER_KEY];

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ID_KEY, user.Id.ToString()),
        });

        context.User.AddIdentity(identity);

        return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
    }
}