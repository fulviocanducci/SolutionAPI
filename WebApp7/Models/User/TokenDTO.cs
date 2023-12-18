namespace WebApp7.Models.User
{
   public class TokenDTO
   {
      public TokenDTO(string token, DateTime? expiration)
      {
         Token = token;
         Expiration = expiration;
      }

      public static TokenDTO Create(string token, DateTime? expiration)
      {
         return new TokenDTO(token, expiration);
      }

      public string Token { get; }
      public DateTime? Expiration { get; }
   }
}
