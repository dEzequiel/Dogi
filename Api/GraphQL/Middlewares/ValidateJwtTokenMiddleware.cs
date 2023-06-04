using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Service.Abstraction.Read;
using Crosscuting.Base.Exceptions;
using HotChocolate.Resolvers;
using Microsoft.IdentityModel.Tokens;

namespace Api.GraphQL.Middlewares;

/// <summary>
/// This middleware is responsible for validating the token and anchoring the user entity to the context of the request.
/// </summary>
public class ValidateJwtTokenMiddleware
{
    private const string ID_KEY = "Id";
    private const string ID_USER = "User";
    private const string HTTP_CONTEXT = "HttpContext";
    private const string HEADER_AUTHORIZATION = "Authorization";
    private const string TOKEN_NOT_VALID = "TOKEN IS IN INVALID STATE";
    private const string UNAUTHORIZED = "UNAUTHORIZED";
    private const string TOKEN_NOT_PRESENT = "TOKEN NOT PRESENT IN REQUEST";
    private readonly FieldDelegate Next;
    private readonly IUserReadService UserReadService;

    public ValidateJwtTokenMiddleware(FieldDelegate next)
    {
        Next = next;
    }

    public async Task InvokeAsync(IMiddlewareContext context, IUserReadService userService)
    {
        var httpCtx = context.ContextData[HTTP_CONTEXT] as HttpContext;

        var token = httpCtx.Request.Headers[HEADER_AUTHORIZATION].FirstOrDefault()?.Split(" ");

        if (token != null)
        {
            await AttachUserToContext(httpCtx, userService, token.Last());
        }
        else
        {
            return;
        }

        // Pass request to next endpoint or middleware.
        await Next(context);
    }

    private async Task AttachUserToContext(HttpContext context, IUserReadService userService, string token)
    {
        try
        {
            // Token handler to validate jwt.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
            }, out SecurityToken validatedToken);

            // Get valid token as JWT.
            var jwtToken = (JwtSecurityToken)validatedToken;

            // Get JWT user identifier.
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == ID_KEY).Value);

            // Attach user to context on successful JWT validation
            context.Items[ID_USER] = await userService.GetByIdAsync(userId);
        }
        catch
        {
            throw new UnauthorizedException(TOKEN_NOT_VALID);
        }
    }
}