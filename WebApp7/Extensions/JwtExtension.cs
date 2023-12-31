﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApp7.Services;
using WebApp7.Settings;
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
               Title = "Sistema de Autenticação e Autorização API",
               Version = "v1",
               Description = "Sistema de Autenticação e Autorização API",
               Contact = new OpenApiContact
               {
                  Name = "Sistema de Autenticação e Autorização API",
                  Email = string.Empty,
                  Url = new Uri("https://www.google.com"),
               },
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
               BearerFormat = "JWT",
               Description = "Sistema de Autenticação e Autorização API",
               In = ParameterLocation.Header,
               Name = "Sistema de Autenticação e Autorização API",
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

      public static IServiceCollection AddAuthenticationJwtBearer(this IServiceCollection services, ConfigurationManager configuration)
      {
         SecretSettings secretSettings = new(configuration);
         services.AddSingleton(_ => secretSettings);
         services.AddSingleton<TokenService>();
         services.AddAuthentication(options =>
         {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         }).AddJwtBearer(options =>
         {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
               ClockSkew = TokenValidationParameters.DefaultClockSkew,
               ValidateAudience = secretSettings.ValidateAudience,
               ValidAudience = secretSettings.Audience,
               ValidateIssuer = secretSettings.ValidateIssuer,
               ValidIssuer = secretSettings.Issuer,
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = secretSettings.SymmetricSecurityKey
            };
         });
         services.AddAuthorization();         
         return services;
      }
   }
}