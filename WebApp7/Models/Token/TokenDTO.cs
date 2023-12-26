namespace WebApp7.Models.Token
{
   public class TokenDTO(string token, DateTime? expiration)
   {
      public static TokenDTO Create(string token, DateTime? expiration)
      {
         return new TokenDTO(token, expiration);
      }

      public string Token { get; } = token;
      public DateTime? Expiration { get; } = expiration;
   }
}
