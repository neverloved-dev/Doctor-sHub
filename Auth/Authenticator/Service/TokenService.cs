using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Authenticator.Models;

namespace Authenticator.Service;

public class TokenService
{
    private  IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] PasswordSalt)
    {
        using (var hmac = new HMACSHA256())
        {
            PasswordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        
    }
    public bool VerifyPassword(string password, byte[] passwordHash, byte[] PasswordSalt)
    {
        using (var hmac = new HMACSHA256(PasswordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    public string CreateToken(User user)
    {
        var tokenKeyValue = _configuration["AppSettings:Token"];
        if (string.IsNullOrEmpty(tokenKeyValue))
        {
            throw new InvalidOperationException("Token key is missing or empty in the configuration.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKeyValue));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: new[]
            {
                new Claim(ClaimTypes.Role, user.Name),
            },
            expires: DateTime.Now.AddDays(10),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

}
