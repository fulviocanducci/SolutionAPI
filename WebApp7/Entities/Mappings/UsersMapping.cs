using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebApp7.Entities.Mappings
{
   public class UsersMapping : IEntityTypeConfiguration<Users>
   {
      public void Configure(EntityTypeBuilder<Users> builder)
      {
         builder.ToTable("users");
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
         builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
         builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(200).IsRequired();
         builder.Property(x => x.Password).HasColumnName("password").HasMaxLength(100).IsRequired();
      }
   }
}
