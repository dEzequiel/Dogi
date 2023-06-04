using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Domain.Entities.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Infraestructure.Authentication;

public class JsonWebTokenProvider : IJsonWebTokenProvider
{
    private readonly IRoleUserReadService RoleUserReadService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="roleUserReadService"></param>
    public JsonWebTokenProvider(IRoleUserReadService roleUserReadService)
    {
        RoleUserReadService = roleUserReadService;
    }

    public async Task<string> Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");

        var claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Email", user.Email),
        };

        // Create Token. It passed then to JwtMiddleware for validation.
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(365),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = "local",
            Audience = "local"
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}