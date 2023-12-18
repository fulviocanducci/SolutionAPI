using WebApp7.Extensions;

namespace WebApp7
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         builder.Services.AddGlobalInjection();
         builder.Services.AddDatabaseContext();
         builder.Services.AddControllers();
         builder.Services.AddCors();
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();
         builder.Services.AddSwaggerGenConfiguration();
         builder.Services.AddAuthenticationJwtBearer();
         builder.Services.AddConfigureDefault();

         var app = builder.Build();

         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }

         app.UseHttpsRedirection();
         app.UseCors();
         app.UseAuthentication();
         app.UseAuthorization();
         app.MapControllers();

         app.Run();
      }
   }
}