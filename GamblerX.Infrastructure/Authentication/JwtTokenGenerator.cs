using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GamblerX.Application.Common.Interfaces.Authentication;
using GamblerX.Application.Common.Interfaces.Services;
using GamblerX.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GamblerX.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwTokenGenerator
{
   
   private readonly JwtSettings _jwtSettings;
   private readonly IDateTimeProvider _dateTimeProvider;

   public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }
   
   
    public string GenerateToken(User user)
    {
       //lets setup a SymmetricSecurityKey and use it to set up 
       //signing credentials for JWT authentication
               
     // Generate a 256-bit key 
        byte[] secretKeyBytes = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
        
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
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
             new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),  // 1 hour expiry
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}