using WebApp7.Entities;

namespace WebApp7.Models.User
{
   public class UserDTO(Users users)
   {
      public int Id { get; private set; } = users.Id;
      public string Name { get; private set; } = users.Name;
      public string Email { get; private set; } = users.Email;

   }
}