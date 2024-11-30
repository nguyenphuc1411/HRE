using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRE.Application.Extentions;

public static class AuthExtentions
{
    public static string GenerateToken(string userID,string jwtKey)
    {

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userID)
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokenDesciption = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = creds
        };
        var token = jwtSecurityTokenHandler.CreateToken(tokenDesciption);
        return jwtSecurityTokenHandler.WriteToken(token);
    }
}
