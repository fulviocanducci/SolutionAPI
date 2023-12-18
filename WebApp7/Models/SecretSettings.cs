using Microsoft.IdentityModel.Tokens;

namespace WebApp7.Models
{
   public class SecretSettings
   {
      public string Key { get; } = "GRABLIchuMparDOCksYNCeoCTUsECtIvGRABLIchuMparDOCksYNCeoCTUsECtIv";
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
