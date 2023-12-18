using System.ComponentModel.DataAnnotations;

namespace WebApp7.Entities
{
   public class Users
   {
      public int Id { get; set; }

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
      [MaxLength(100)]
      public string Password { get; set; } = string.Empty;
   }
}