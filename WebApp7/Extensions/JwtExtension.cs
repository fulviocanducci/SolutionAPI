using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApp7.Models;
using WebApp7.Services;
namespace WebApp7.Extensions
{
   public static class JwtExtension
   {
      public static IServiceCollection AddAuthenticationJwtBearer(this IServiceCollection services)
      {
         SecretSettings secretSettings = new();
         services.AddSingleton(_ => secretSettings);
         services.AddSingleton<TokenService>();
         services.AddAuthentication().AddJwtBearer(options =>
         {            
            options.SaveToken = true;            
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
               ClockSkew = TokenValidationParameters.DefaultClockSkew,
               ValidateAudience = false,
               ValidateIssuer = false,               
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = secretSettings.SymmetricSecurityKey               
            };
         });
         services.AddAuthorization();
         return services;
      }
   }
}
