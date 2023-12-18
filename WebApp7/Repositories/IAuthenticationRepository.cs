using WebApp7.Models.User;

namespace WebApp7.Repositories
{
   public interface IAuthenticationRepository
   {
      Task<UserDTO?> GetUserByEmailAsync(string? email);
      Task<bool> IsUserByEmailAndPasswordAsync(UserLogin userLogin);
   }
}