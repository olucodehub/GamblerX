using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using GamblerX.Application.Common.Interfaces.Authentication;
using GamblerX.Application.Common.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace GamblerX.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwTokenGenerator
{
   private readonly IDateTimeProvider _dateTimeProvider;

   public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }
   
   
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
       //lets setup a SymmetricSecurityKey and use it to set up 
       //signing credentials for JWT authentication
               
        // Generate a 256-bit key 
        byte[] secretKeyBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create()) 
        {
            rng.GetBytes(secretKeyBytes);
        }
        
        // Create a SymmetricSecurityKey using the secretKeyBytes
        var securityKey = new SymmetricSecurityKey(secretKeyBytes);

        // Create signing credentials using the security key and the HMACSHA256 algorithm
        var signingCredentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256
        );
       
       // setup the associated claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
             new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "GamblerX",
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),  // 1 hour expiry
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}