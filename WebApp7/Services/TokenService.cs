using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApp7.Models;
using WebApp7.Models.User;
namespace WebApp7.Services
{
   public class TokenService
   {
      public SecretSettings SecretSettings { get; }

      public TokenService(SecretSettings secretSettings)
      {
         SecretSettings = secretSettings;
      }

      public TokenDTO Generate(UserLogin model)
      {
         JwtSecurityTokenHandler handler = new();
         SecurityTokenDescriptor tokenDescriptor = new()
         {
            Subject = new ClaimsIdentity(GenerateClaims(model)),
            SigningCredentials = new SigningCredentials
            (
               SecretSettings.SymmetricSecurityKey,
               SecurityAlgorithms.HmacSha256Signature
            ),
            Expires = DateTime.UtcNow.AddHours(8),
            Audience = SecretSettings.Audience,
            Issuer = SecretSettings.Issuer
         };
         SecurityToken token = handler.CreateToken(tokenDescriptor);
         return new TokenDTO(handler.WriteToken(token), tokenDescriptor.Expires);
      }

      private static ClaimsIdentity GenerateClaims(UserLogin model)
      {
         ClaimsIdentity claimsIdentity = new();
         claimsIdentity.AddClaim(new Claim("jti", Guid.NewGuid().ToString()));
         claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, model.Email));
         claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, model.Email));
         claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.Email));
         return claimsIdentity;
      }
   }
}
