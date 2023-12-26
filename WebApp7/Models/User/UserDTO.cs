using WebApp7.Entities;

namespace WebApp7.Models.User
{
   public class UserDTO
   {
      public UserDTO(Users users)
      {
         Id = users.Id;
         Name = users.Name;
         Email = users.Email;
      }

      public int Id { get; private set; }
      public string Name { get; private set; } = string.Empty;
      public string Email { get; private set; } = string.Empty;

   }
}