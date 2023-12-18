using Microsoft.EntityFrameworkCore;
using WebApp7.Databases;
using WebApp7.Entities;
using WebApp7.Models.User;
namespace WebApp7.Repositories
{
   public class UsersRepository(DatabaseContext databaseContext) : IUsersRepository
   {
      public async Task<List<UserDTO>> GetAllAsync()
      {
         return await databaseContext.Users
            .Select(u => new UserDTO(u))
            .AsNoTracking()
            .ToListAsync();
      }

      public async Task<UserDTO?> CreateAsync(UserCreate userCreate)
      {
         Users user = userCreate;
         await databaseContext.Users.AddAsync(user);
         if ((await databaseContext.SaveChangesAsync()) > 0)
         {
            UserDTO userDto = new(user);
            return userDto;
         }
         return null;
      }
   }
}
