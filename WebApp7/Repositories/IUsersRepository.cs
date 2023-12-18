using WebApp7.Models.User;

namespace WebApp7.Repositories
{
   public interface IUsersRepository
   {
      Task<UserDTO?> CreateAsync(UserCreate userCreate);
      Task<List<UserDTO>> GetAllAsync();
   }
}