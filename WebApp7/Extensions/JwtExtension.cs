using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApp7.Models;
using WebApp7.Services;
namespace WebApp7.Extensions
{
   public static class JwtExtension
   {
      public static IServiceCollection AddSwaggerGenConfiguration(this IServiceCollection services)
      {
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
               Title = "Authorization",
               Version = "v1",
               Description = "Authorization",
               Contact = new OpenApiContact
               {
                  Name = "Authorization",
                  Email = string.Empty,
                  Url = new Uri("https://www.google.com"),
               },
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
               BearerFormat = "JWT",
               Description = "Authorization",
               In = ParameterLocation.Header,
               Name = "Authorization",
               Type = SecuritySchemeType.ApiKey,
               Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
         });
         return services;
      }

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
