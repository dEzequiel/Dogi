using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using Application.Service.Abstraction.Read;
using Crosscuting.Base.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Infraestructure.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate Next;

    private const string TOKEN_NOT_VALID = "TOKEN IS IN INVALID STATE";
    private const string UNAUTHORIZED = "UNAUTHORIZED";
    private const string TOKEN_NOT_PRESENT = "TOKEN NOT PRESENT IN REQUEST";


    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="next"></param>
    public JwtMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    private async Task TokenNotPresent(HttpResponse response)
    {
        response.StatusCode = StatusCodes.Status422UnprocessableEntity;
        response.ContentType = "application/json";

        var responseBody = JsonSerializer.Serialize(new
        {
            name = TOKEN_NOT_PRESENT,
            statusCode = StatusCodes.Status422UnprocessableEntity,
            statusText = TOKEN_NOT_PRESENT,
            bodyText = ""
        });

        await response.WriteAsync(responseBody);
    }


    public async Task Invoke(HttpContext context, IUserReadService userService)
    {
        if (context is null)
        {
            var httpResponse = new DefaultHttpContext().Response;
            await TokenNotPresent(httpResponse);
            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ");

        if (token is null || token.Length < 2 || token.Length > 2)
        {
            var httpResponse = new DefaultHttpContext().Response;
            await TokenNotPresent(httpResponse);
            return;
        }


        if (token != null)
        {
            await attachUserToContext(context, userService, token.Last());
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            var response = new
            {
                name = UNAUTHORIZED,
                statusCode = StatusCodes.Status401Unauthorized,
                statusText = UNAUTHORIZED,
                bodyText = ""
            };

            var responseBody = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(responseBody);
            return;
        }

        // Pass request to next endpoint or middleware.
        await Next(context);
    }


    private async Task attachUserToContext(HttpContext context, IUserReadService userService, string token)
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
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);

            // Get valid token as JWT.
            var jwtToken = (JwtSecurityToken)validatedToken;

            // Get JWT user identifier.
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // Attach user to context on successful JWT validation
            context.Items["User"] = await userService.GetByIdAsync(userId);
        }
        catch
        {
            throw new UnauthorizedException(TOKEN_NOT_VALID);
        }
    }
}