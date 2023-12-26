using Microsoft.IdentityModel.Tokens;
namespace WebApp7.Settings
{
   public class SecretSettings(ConfigurationManager configuration)
   {
      public string Key { get; private set; } = configuration.GetValue<string>("Jwt:Key") ?? "";
      public string Audience { get; private set; } = configuration.GetValue<string>("Jwt:Audience") ?? "";
      public bool ValidateAudience { get; private set; } = configuration.GetValue<bool>("Jwt:ValidateAudience");
      public bool ValidateIssuer { get; private set; } = configuration.GetValue<bool>("Jwt:ValidateIssuer");
      public string Issuer { get; private set; } = configuration.GetValue<string>("Jwt:Issuer") ?? "";
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
