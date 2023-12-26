using Microsoft.EntityFrameworkCore;
using WebApp7.Databases;
using WebApp7.Models.User;
namespace WebApp7.Repositories
{
   public class AuthenticationRepository(DatabaseContext databaseContext) : IAuthenticationRepository
   {
      public async Task<UserDTO?> GetUserByEmailAsync(string? email)
      {
         if (email is not null)
         {
            return await databaseContext
               .Users
               .Where(c => c.Email == email)
               .Select(u => new UserDTO(u))
               .FirstOrDefaultAsync();
         }
         return null;
      }

      public async Task<bool> IsUserByEmailAndPasswordAsync(UserLogin userLogin)
      {
         return await databaseContext
                     .Users
                     .Where(c => c.Email == userLogin.Email && c.Password == userLogin.Password)
                     .AnyAsync();
      }
   }
}
