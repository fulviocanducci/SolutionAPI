using Microsoft.IdentityModel.Tokens;

namespace WebApp7.Models
{
   public class SecretSettings
   {
      public SecretSettings(ConfigurationManager configuration)
      {
         Key = configuration.GetValue<string>("Jwt:Key") ?? "";
         Audience = configuration.GetValue<string>("Jwt:Audience") ?? "";
         Issuer = configuration.GetValue<string>("Jwt:Issuer") ?? "";
         ValidateAudience = configuration.GetValue<bool>("Jwt:ValidateAudience");
         ValidateIssuer = configuration.GetValue<bool>("Jwt:ValidateIssuer");
      }

      public string Key { get; private set; }
      public string Audience { get; private set; }
      public bool ValidateAudience { get; private set; }
      public bool ValidateIssuer { get; private set; }
      public string Issuer { get; private set; }
      public SymmetricSecurityKey SymmetricSecurityKey
      {
         get
         {
            if (string.IsNullOrEmpty(Key)) throw new ArgumentNullException(nameof(Key));
            return new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Key));
         }
      }
   }
}
