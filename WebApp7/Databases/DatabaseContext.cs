using Microsoft.EntityFrameworkCore;
using WebApp7.Entities;
using WebApp7.Entities.Mappings;

namespace WebApp7.Databases
{
   public class DatabaseContext : DbContext
   {
      public DatabaseContext(DbContextOptions options) : base(options) { Database.EnsureCreated(); }

      public DbSet<Users> Users { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new UsersMapping());
      }
   }
}