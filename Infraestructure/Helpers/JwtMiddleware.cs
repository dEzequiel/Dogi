using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Service.Abstraction.Read;
using Crosscuting.Base.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Infraestructure.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate Next;

    private const string ID_KEY = "Id";
    private const string ID_USER = "User";
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

    public async Task Invoke(HttpContext context, IUserReadService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ");

        if (token != null)
        {
            await attachUserToContext(context, userService, token.Last());
        }
        else
        {
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