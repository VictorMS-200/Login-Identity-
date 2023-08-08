using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entity.Models;
using Microsoft.IdentityModel.Tokens;

namespace Entity.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.DateBirth.ToString()),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperMegaHyperSecretKeyThatNobodyKnowsAboutIt@123456789"));

        var singingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: singingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}