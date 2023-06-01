using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Service.Abstraction.Read;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Infraestructure.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserReadService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            await attachUserToContext(context, userService, token);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        // Pass request to next endpoint or middleware.
        await _next(context);
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

            // Attach user to context on successful jwt validation
            context.Items["User"] = await userService.GetByIdAsync(userId);
        }
        catch
        {
            // do nothing if jwt validation fails
            // user is not attached to context so request won't have access to secure routes
        }
    }
}