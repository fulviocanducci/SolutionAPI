using Microsoft.EntityFrameworkCore;
using WebApp7.Databases;
using WebApp7.Repositories;

namespace WebApp7.Extensions
{
   public static class ConfigurationExtension
   {
      public static IServiceCollection AddConfigureDefault(this IServiceCollection services)
      {
         services.Configure<RouteOptions>(options =>
         {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
         });
         return services;
      }

      public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
      {
         services.AddDbContext<DatabaseContext>(config =>
         {
            config.UseSqlite("Data Source=db.sqlite");
         });
         return services;
      }

      public static IServiceCollection AddGlobalInjection(this IServiceCollection services)
      {
         services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
         services.AddScoped<IUsersRepository, UsersRepository>();
         return services;
      }
   }
}