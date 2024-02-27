using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TokenBasedAuthWithDotNet;

public class JwtTokenManager : IJwtTokenManager
{
    private readonly IConfiguration _configuration;
    public JwtTokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Authenticate(string userName, string password)
    {
        if (!Data.Users.Any(x => x.Key.Equals(userName)
                                 && x.Value.Equals(password)))
            return null;

        var key = _configuration.GetValue<string>("JwtConfig:Key");
            
        var keyBytes = Encoding.UTF8.GetBytes(key);

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.NameIdentifier, userName)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}