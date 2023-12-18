using System.ComponentModel.DataAnnotations;
using WebApp7.Entities;

namespace WebApp7.Models.User
{
   public class UserCreate
   {
      [Required()]
      [MinLength(3)]
      [MaxLength(100)]
      public string Name { get; set; } = string.Empty;

      [Required()]
      [MinLength(3)]
      [MaxLength(200)]
      [EmailAddress()]
      public string Email { get; set; } = string.Empty;

      [Required()]
      [MinLength(8)]
      public string Password { get; set; } = string.Empty;

      public static implicit operator Users(UserCreate model)
      {
         return new Users
         {
            Id = 0,
            Name = model.Name,
            Email = model.Email,
            Password = model.Password
         };
      }
   }
}

